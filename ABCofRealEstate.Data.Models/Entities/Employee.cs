using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models.Entities
{
    [Table("employee")]
    public class Employee : BaseEntity
    {
        public Employee(
            string email,
            string fullName,
            EnumJobTitleEmployee jobTitle,
            string numberPhone)
        {
            Email = email;
            FullName = fullName;
            JobTitle = jobTitle;
            NumberPhone = numberPhone;
        }
        /// <summary> Электронный адресс(e-mail) работника </summary>
        [Display(Name = "email")]
        public string Email { get; init; }
        /// <summary> ФИО работника </summary>
        [Display(Name = "full_name")]
        public string FullName { get; init; }
        /// <summary> Должность работника </summary>
        [Display(Name = "job_title")]
        public EnumJobTitleEmployee JobTitle { get; init; }
        /// <summary> Номер(а) телефон(а/ов) работника </summary>
        [Display(Name = "number_phone")]
        public string NumberPhone { get; init; }
    }
}
