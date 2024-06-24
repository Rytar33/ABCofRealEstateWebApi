using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ABCofRealEstate.Services.Extensions;
using ABCofRealEstate.Services.Models.Moderators;
using ABCofRealEstate.Services.Models.Page;
using Microsoft.IdentityModel.Tokens;

namespace ABCofRealEstate.Services
{
    public class ModeratorService : IModeratorService
    {
        public async Task<BaseResponse<ModeratorDetailResponse>> Create(ModeratorCreateRequest moderatorCreateRequest)
        {
            var moderator = new Moderator(
                moderatorCreateRequest.Name,
                moderatorCreateRequest.Email,
                moderatorCreateRequest.Password);
            await using var db = new RealEstateDataContext();
            await db.Moderator.AddAsync(moderator);
            await db.SaveChangesAsync();
            return await Get(moderator.Id);
        }
        public async Task<BaseResponse<ModeratorDetailResponse>> Change(ModeratorChangeRequest moderatorChangeRequest)
        {
            await using var db = new RealEstateDataContext();
            var moderatorGet = await db.Moderator.AsNoTracking().FirstOrDefaultAsync(m => m.Id == moderatorChangeRequest.Id);
            if (moderatorGet == null)
                return new BaseResponse<ModeratorDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Такого модератора не было найдено"
                };
            var moderator = new Moderator(
                moderatorChangeRequest.Name,
                moderatorChangeRequest.Email,
                moderatorGet.Password)
            {
                Id = moderatorChangeRequest.Id,
                IsSuperModerator = moderatorChangeRequest.IsSuperModerator
            };
            db.Moderator.Update(moderator);
            await db.SaveChangesAsync();
            return await Get(moderator.Id);
        }

        public async Task<BaseResponse<ModeratorLogInResponse>> LogIn(ModeratorAuthenticationRequest moderatorAuthenticationRequest)
        {
            await using var db = new RealEstateDataContext();
            var moderator = await db.Moderator
                .AsNoTracking()
                .FirstOrDefaultAsync(m => 
                    (m.Email == moderatorAuthenticationRequest.EmailOrName 
                    || m.Name == moderatorAuthenticationRequest.EmailOrName) 
                    && m.Password == moderatorAuthenticationRequest.Password.GetSha256());
            if (moderator == null)
                return new BaseResponse<ModeratorLogInResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Ошибка аунтефикации, неправильнно введены логин и/или пароль"
                };
            string key = "mysupersecret_secretsecretsecretkey!123";
            var jwt = new JwtSecurityToken(
                issuer: "MyAuthServer",
                audience: "MyAuthClient",
                claims: new List<Claim>()
                {
                    new(nameof(Moderator.Id), moderator.Id.ToString()),
                    new(nameof(Moderator.IsSuperModerator), moderator.IsSuperModerator.ToString())
                },
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(7)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256));
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new BaseResponse<ModeratorLogInResponse>()
            {
                IsSuccess = true,
                Data = new ModeratorLogInResponse(
                    jwtToken,
                    moderator.Id)
            };

        }
        public async Task<BaseResponse<ModeratorDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var moderator = await db.Moderator.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (moderator == null)
                return new BaseResponse<ModeratorDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Модератор не был найден"
                };
            return new BaseResponse<ModeratorDetailResponse>
            {
                IsSuccess = true,
                Data = new ModeratorDetailResponse(
                    moderator.Id,
                    moderator.Name,
                    moderator.Email,
                    moderator.IsSuperModerator)
            };
        }

        public async Task<BaseResponse<ModeratorListResponse>> GetPage(ModeratorListRequest moderatorListRequest)
        {
            await using var db = new RealEstateDataContext();
            var moderators = await db.Moderator.ToListAsync();
            if (!moderators.Any())
                return new BaseResponse<ModeratorListResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Модераторов не было найденно"
                };
            var moderatorsQueryable = moderators.AsQueryable();
            
            if (moderatorListRequest.Search != null)
                moderatorsQueryable = moderatorsQueryable
                    .Where(m =>
                        m.Name.Contains(moderatorListRequest.Search)
                        || m.Email.Contains(moderatorListRequest.Search));
            if (moderatorListRequest.IsSuperModerator != null)
                moderatorsQueryable = moderatorsQueryable
                    .Where(m => m.IsSuperModerator == moderatorListRequest.IsSuperModerator);
            
            var countModerators = moderatorsQueryable.Count();
            moderatorsQueryable = moderatorsQueryable
                .Skip((moderatorListRequest.Page!.Page - 1) * moderatorListRequest.Page!.PageSize)
                .Take(moderatorListRequest.Page!.PageSize);
            
            return new BaseResponse<ModeratorListResponse>()
            {
                IsSuccess = true,
                Data = new ModeratorListResponse(
                    moderatorsQueryable.Select(m => 
                            new ModeratorListItem(
                                m.Id,
                                m.Name,
                                m.Email,
                                m.IsSuperModerator))
                        .AsEnumerable(),
                    new PageResponse(
                        moderatorListRequest.Page.Page,
                        moderatorListRequest.Page.PageSize,
                        countModerators))
            };
        }
        public async Task<BaseResponse<ModeratorDetailResponse>> Delete(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var moderator = await db.Moderator.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (moderator == null)
                return new BaseResponse<ModeratorDetailResponse> 
                    { 
                        IsSuccess = false, 
                        ErrorMessage = "Модератор не был найден"
                    };
            db.Moderator.Remove(moderator);
            await db.SaveChangesAsync();
            return new BaseResponse<ModeratorDetailResponse> { IsSuccess = true };
        }
    }
}
