using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Employee
    {
        /// <summary> Идентификатор работника </summary>
        [Key]
        [Display(Name = "ID_Employee")]
        public int IdEmployee { get; set; }
        /// <summary> Идентификатор фотографии работника </summary>
        public int IdImg { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Image? Image { get; set; }
        /// <summary> Электронный адресс(e-mail) работника </summary>
        public string Email { get; set; } = null!;
        /// <summary> ФИО работника </summary>
        public string FullName { get; set; } = null!;
        /// <summary> Должность работника </summary>
        public EnumJobTitleEmployee JobTitle { get; set; }
        /// <summary> Номер(а) телефон(а/ов) работника </summary>
        public string NumberPhone { get; set; } = null!;
    }
}
