using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Extensions;
using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Moderators;
using ABCofRealEstate.Services.Validations.Moderators;
using Microsoft.EntityFrameworkCore;

namespace ABCofRealEstate.Services
{
    public class ModeratorService
    {
        public async Task<BaseResponse<ModeratorDetailResponse>> Create(ModeratorCreateRequest moderatorCreateRequest)
        {
            var resultValidation = moderatorCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            var moderator = new Moderator()
            {
                Name = moderatorCreateRequest.Name,
                Email = moderatorCreateRequest.Email,
                Password = moderatorCreateRequest.Password.GetSha256(),
                AccessLevel = moderatorCreateRequest.AccessLevel
            };
            using var db = new RealEstateDataContext();
            await db.Moderator.AddAsync(moderator);
            await db.SaveChangesAsync();
            return await Get(moderator.Id);
        }
        public async Task<BaseResponse<ModeratorDetailResponse>> Change(ModeratorChangeRequest moderatorChangeRequest)
        {
            var resultValidation = moderatorChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            if (!await db.Moderator.AnyAsync(m => m.Id == moderatorChangeRequest.IdModerator))
                return new BaseResponse<ModeratorDetailResponse>()
                {
                    IsSuccses = false,
                    ErrorMessage = "Такого модератора не было найдено"
                };
            var moderator = new Moderator()
            {
                Id = moderatorChangeRequest.IdModerator,
                Name = moderatorChangeRequest.Name,
                Email = moderatorChangeRequest.Email,
                Password = moderatorChangeRequest.Password.GetSha256(),
                AccessLevel = moderatorChangeRequest.AccessLevel,
                IsSuperModerator = moderatorChangeRequest.IsSuperModerator
            };
            db.Moderator.Update(moderator);
            await db.SaveChangesAsync();
            return await Get(moderator.Id);
        }
        public async Task<BaseResponse<ModeratorDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var moderator = await db.Moderator.FirstOrDefaultAsync(m => m.Id == id);
            if (moderator == null)
                return new BaseResponse<ModeratorDetailResponse>() { IsSuccses = false, ErrorMessage = "Дом не был найден" };
            return new BaseResponse<ModeratorDetailResponse>()
            {
                IsSuccses = true,
                Data = new ModeratorDetailResponse()
                {
                    IdModerator = moderator.Id,
                    Name = moderator.Name,
                    Email = moderator.Email,
                    AccessLevel = moderator.AccessLevel,
                    IsSuperModerator= moderator.IsSuperModerator
                }
            };
        }

        public async Task<BaseResponse<ModeratorDetailResponse>> Delete(Guid id)
        {
            using var db = new RealEstateDataContext();
            var moderator = await db.Moderator.FirstOrDefaultAsync(m => m.Id == id);
            if (moderator == null)
                return new BaseResponse<ModeratorDetailResponse>() { IsSuccses = false, ErrorMessage = "Модератор не был найден" };
            db.Moderator.Remove(moderator);
            await db.SaveChangesAsync();
            return new BaseResponse<ModeratorDetailResponse>() { IsSuccses = true };
        }
    }
}
