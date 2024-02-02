using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    [Table("employee")]
    public class Employee
    {
        /// <summary> Идентификатор работника </summary>
        [Key]
        [Display(Name = "id")]
        public Guid Id { get; set; }
        /// <summary> Электронный адресс(e-mail) работника </summary>
        [Display(Name = "email")]
        public string Email { get; set; } = null!;
        /// <summary> ФИО работника </summary>
        [Display(Name = "full_name")]
        public string FullName { get; set; } = null!;
        /// <summary> Должность работника </summary>
        [Display(Name = "job_title")]
        public EnumJobTitleEmployee JobTitle { get; set; }
        /// <summary> Номер(а) телефон(а/ов) работника </summary>
        [Display(Name = "number_phone")]
        public string NumberPhone { get; set; } = null!;
    }
}
