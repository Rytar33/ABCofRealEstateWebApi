using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Модератор" </summary>
    [Table("moderator")]
    public class Moderator
    {
        /// <summary> Идентификатор модератора </summary>
        [Key]
        [Display(Name = "id")]
        public Guid Id { get; set; }
        /// <summary> Имя модератора </summary>
        [Display(Name = "name")]
        public string Name { get; set; } = null!;
        /// <summary> Почта модератора </summary>
        [Display(Name = "email")]
        public string Email { get; set; } = null!;
        /// <summary> Пароль модератора </summary>
        [Display(Name = "password")]
        public string Password { get; set; } = null!;
        /// <summary> Уровень доступа у модератора </summary>
        [Display(Name = "access_level")]
        public EnumAccessLevel AccessLevel { get; set; }
        /// <summary> Обладает ли модератор расширенными правами </summary>
        [Display(Name = "is_super_moderator")]
        public bool IsSuperModerator { get; set; } = false;
    }
}
