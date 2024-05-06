using ABCofRealEstate.Services.Models.Employees;
using ABCofRealEstate.Services.Models.Page;
using ABCofRealEstate.Services.Validations.Employees;

namespace ABCofRealEstate.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<BaseResponse<EmployeeDetailResponse>> Create(EmployeeCreateRequest employeeCreateRequest)
        {
            var resultValidation = employeeCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;

            var employee = new Employee(
                employeeCreateRequest.Email,
                employeeCreateRequest.FullName,
                employeeCreateRequest.JobTitle,
                employeeCreateRequest.NumberPhone);
            await using var db = new RealEstateDataContext();
            await db.Employee.AddAsync(employee);
            await db.SaveChangesAsync();
            if (employeeCreateRequest.File != null)
                await ExportImageService.ImportSingleFile(
                $"wwwroot/images/team/{employee.Id}",
                employeeCreateRequest.File);
            return await Get(employee.Id);
        }
        public async Task<BaseResponse<EmployeeDetailResponse>> Change(EmployeeChangeRequest apartmentChangeRequest)
        {
            var resultValidation = apartmentChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            await using var db = new RealEstateDataContext();
            if(!await db.Employee.AnyAsync(e => e.Id == apartmentChangeRequest.Id))
                return new BaseResponse<EmployeeDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Такого работника не было найденно"
                };
            var employee = new Employee(
                apartmentChangeRequest.Email,
                apartmentChangeRequest.FullName,
                apartmentChangeRequest.JobTitle,
                apartmentChangeRequest.NumberPhone)
            {
                Id = apartmentChangeRequest.Id
            };
            db.Employee.Update(employee);
            await db.SaveChangesAsync();
            return await Get(employee.Id);
        }
        public async Task<BaseResponse<EmployeeDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var employee = await db.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return new BaseResponse<EmployeeDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Работник не был найден"
                };
            var fullPath = ExportImageService.ExportFullPathImage($"wwwroot/images/team/{employee.Id}");
            return new BaseResponse<EmployeeDetailResponse>
            {
                IsSuccess = true,
                Data = new EmployeeDetailResponse(
                    fullPath,
                    employee.Id,
                    employee.Email,
                    employee.FullName,
                    employee.JobTitle,
                    employee.NumberPhone)
            };
        }
        public async Task<BaseResponse<EmployeeListResponse>> GetPage(EmployeeListRequest employeeListRequest)
        {
            await using var db = new RealEstateDataContext();
            var employees = db.Employee;
            if (!employees.Any())
                return new BaseResponse<EmployeeListResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Работников не было найдено"
                };
            var employeesQueryable = employees.AsQueryable();
            var countEmployees = employeesQueryable.Count();
            
            employeesQueryable = employeesQueryable
                .Skip((employeeListRequest.Page!.Page - 1) * employeeListRequest.Page.PageSize)
                .Take(employeeListRequest.Page.PageSize);
            return new BaseResponse<EmployeeListResponse>
            {
                IsSuccess = true,
                Data = new EmployeeListResponse(
                    employeesQueryable.Select(e => 
                        new EmployeeListItem(
                            ExportImageService.ExportFullPathImage($"wwwroot/images/team/{e.Id}") ??
                            ExportImageService.ExportFullPathImage("wwwroot/images/team"),
                            e.Id,
                            e.Email,
                            e.FullName,
                            e.JobTitle,
                            e.NumberPhone)).ToList(),
                    new PageResponse(
                        employeeListRequest.Page.Page,
                        employeeListRequest.Page.PageSize,
                        countEmployees))
            };
        }

        public async Task<BaseResponse<IEnumerable<EmployeeGetShortListResponse>>> GetShortList()
        { 
            await using var db = new RealEstateDataContext();
            var employees = db.Employee
                .AsNoTracking()
                .Select(e => 
                    new EmployeeGetShortListResponse 
                    { 
                        IdEmployee = e.Id, 
                        FullName = e.FullName 
                    }).ToList();
            return new BaseResponse<IEnumerable<EmployeeGetShortListResponse>>
            {
                IsSuccess = true,
                Data = employees
            };
        }
        
        public async Task<BaseResponse<EmployeeDetailResponse>> Delete(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var employee = await db.Employee
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return new BaseResponse<EmployeeDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Работник не был найден"
                };
            await db.Apartment
                .Where(a => a.EmployeeId == id)
                .ExecuteUpdateAsync(a => a.SetProperty(sa => sa.EmployeeId, sa=> null));
            await db.Area
                .Where(a => a.EmployeeId == id)
                .ExecuteUpdateAsync(a => a.SetProperty(sa => sa.EmployeeId, sa=> null));
            await db.Comertion
                .Where(c => c.EmployeeId == id)
                .ExecuteUpdateAsync(c => c.SetProperty(sc => sc.EmployeeId, sc=> null));
            await db.Garage
                .Where(g => g.EmployeeId == id)
                .ExecuteUpdateAsync(g => g.SetProperty(sg => sg.EmployeeId, sg=> null));
            await db.Hostel
                .Where(h => h.EmployeeId == id)
                .ExecuteUpdateAsync(h => h.SetProperty(sh => sh.EmployeeId, sh=> null));
            await db.House
                .Where(h => h.EmployeeId == id)
                .ExecuteUpdateAsync(h => h.SetProperty(sh => sh.EmployeeId, sh=> null));
            await db.Room
                .Where(r => r.EmployeeId == id)
                .ExecuteUpdateAsync(r => r.SetProperty(sr => sr.EmployeeId, sr=> null));
            db.Employee.Remove(employee);
            await db.SaveChangesAsync();
            ExportImageService.RemovePathWithFiles($"wwwroot/images/team/{id}");
            return new BaseResponse<EmployeeDetailResponse> { IsSuccess = true };
        }
    }
}
