using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Модератор" </summary>
    [Table("moderator")]
    public class Moderator
    {
        public Moderator(
            string name,
            string email,
            string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        /// <summary> Идентификатор модератора </summary>
        [Key]
        [Display(Name = "id")]
        public Guid Id { get; init; }
        /// <summary> Имя модератора </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        [Display(Name = "name")]
        public string Name { get; init; }
        /// <summary> Почта модератора </summary>
        [Display(Name = "email")]
        public string Email { get; init; }
        /// <summary> Пароль модератора </summary>
        [Display(Name = "password")]
        public string Password { get; init; }
        /// <summary> Обладает ли модератор расширенными правами </summary>
        [Display(Name = "is_super_moderator")]
        public bool IsSuperModerator { get; init; } = false;
    }
}
