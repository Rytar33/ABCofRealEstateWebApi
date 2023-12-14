using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Employees;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Employees;
using ABCofRealEstate.Services.Models.Apartaments;
using ABCofRealEstate.Services.Models.Images;

namespace ABCofRealEstate.Services
{
    public class EmployeeService
    {
        public async Task<BaseResponse> Create(EmployeeCreateRequest employeeCreateRequest)
        {
            var resultValidation = employeeCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();
            if (employeeCreateRequest.IdImg == null && employeeCreateRequest.Image != null)
            {
                var resultResponse = await new ImageService().Create(
                    new ImageCreateRequest()
                    {
                        FileName = employeeCreateRequest.Image.FileName,
                        Title = employeeCreateRequest.Image.Title,
                        DataImg = employeeCreateRequest.Image.DataImg
                    });
                if (resultResponse.IsSuccses == false)
                    return resultResponse;
                employeeCreateRequest.IdImg = db.Image.Last().IdImg;
            }

            await db.Employee.AddAsync(
                new Employee()
                {
                    FullName = employeeCreateRequest.FullName,
                    Email = employeeCreateRequest.Email,
                    IdImg = employeeCreateRequest.IdImg,
                    Image = employeeCreateRequest.Image,
                    JobTitle = employeeCreateRequest.JobTitle,
                    NumberPhone = employeeCreateRequest.NumberPhone
                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(EmployeeChangeRequest employeeChangeRequest)
        {
            var resultValidation = employeeChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public EmployeeDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var employee = db.Employee.FirstOrDefaultAsync(e => e.IdEmployee == id);
            if (employee == null)
                return new EmployeeDetailResponse() { IsSuccses = false, ErrorMessage = "Работник не был найден" };
            return new EmployeeDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var employee = db.Employee.FirstOrDefaultAsync(e => e.IdEmployee == id);
            if (employee == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Работник не был найден" };
            db.Employee.Remove(await employee);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
