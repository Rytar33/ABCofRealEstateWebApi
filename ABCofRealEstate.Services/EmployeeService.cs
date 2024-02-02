using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Employees;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Employees;
using ABCofRelEstate.ExportTool;

namespace ABCofRealEstate.Services
{
    public class EmployeeService
    {
        public async Task<BaseResponse<EmployeeDetailResponse>> Create(EmployeeCreateRequest employeeCreateRequest)
        {
            var resultValidation = employeeCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            var employee = new Employee()
            {
                FullName = employeeCreateRequest.FullName,
                Email = employeeCreateRequest.Email,
                JobTitle = employeeCreateRequest.JobTitle,
                NumberPhone = employeeCreateRequest.NumberPhone
            };
            using var db = new RealEstateDataContext();
            await db.Employee.AddAsync(employee);
            await db.SaveChangesAsync();
            if (employeeCreateRequest.File != null)
                await new ExportJpgService()
                .ImportSingleFile(
                $"~/Files/Img/Team/{employee.Id}",
                employeeCreateRequest.File);
            return await Get(employee.Id);
        }
        public async Task<BaseResponse<EmployeeDetailResponse>> Change(EmployeeChangeRequest employeeChangeRequest)
        {
            var resultValidation = employeeChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            if(!await db.Employee.AnyAsync(e => e.Id == employeeChangeRequest.IdEmployee))
                return new BaseResponse<EmployeeDetailResponse>() 
                {
                    IsSuccses = false,
                    ErrorMessage = "Такого работника не было найденно"
                };
            var employee = new Employee()
            {
                Id = employeeChangeRequest.IdEmployee,
                FullName = employeeChangeRequest.FullName,
                Email = employeeChangeRequest.Email,
                JobTitle = employeeChangeRequest.JobTitle,
                NumberPhone = employeeChangeRequest.NumberPhone
            };
            db.Employee.Update(employee);
            await db.SaveChangesAsync();
            return await Get(employee.Id);
        }
        public async Task<BaseResponse<EmployeeDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var employee = await db.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return new BaseResponse<EmployeeDetailResponse>() { IsSuccses = false, ErrorMessage = "Работник не был найден" };
            string? fullPath = new ExportJpgService().ExportFullPathJpg($"~/Files/Img/Team/{employee.Id}");
            return new BaseResponse<EmployeeDetailResponse>()
            {
                IsSuccses = true,
                Data = new EmployeeDetailResponse()
                {
                    FullPathFile = fullPath,
                    IdEmployee = employee.Id,
                    FullName = employee.FullName,
                    Email = employee.Email,
                    JobTitle = employee.JobTitle,
                    NumberPhone = employee.NumberPhone
                }
            };
        }
        public async Task<BaseResponse<List<EmployeeDetailResponse>>> GetAllEmployees()
        {
            using var db = new RealEstateDataContext();
            var employees = await db.Employee.ToListAsync();
            if (!employees.Any())
                return new BaseResponse<List<EmployeeDetailResponse>>()
                {
                    IsSuccses = false,
                    ErrorMessage = "Работников не было найдено"
                };
            return new BaseResponse<List<EmployeeDetailResponse>>()
            {
                IsSuccses = true,
                Data = employees.Select(e => 
                new EmployeeDetailResponse() 
                {
                    IdEmployee = e.Id,
                    FullName = e.FullName,
                    Email = e.Email,
                    JobTitle = e.JobTitle,
                    NumberPhone = e.NumberPhone
                })
                .ToList()
            };
        }
        public async Task<BaseResponse<EmployeeDetailResponse>> Delete(Guid id)
        {
            using var db = new RealEstateDataContext();
            var employee = await db.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return new BaseResponse<EmployeeDetailResponse>() { IsSuccses = false, ErrorMessage = "Работник не был найден" };
            db.Employee.Remove(employee);
            await db.SaveChangesAsync();
            return new BaseResponse<EmployeeDetailResponse>() { IsSuccses = true };
        }
    }
}
