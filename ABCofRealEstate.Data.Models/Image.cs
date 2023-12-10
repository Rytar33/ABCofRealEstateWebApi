using System.ComponentModel.DataAnnotations;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Изображение" </summary>
    public class Image
    {
        /// <summary> Идентификатор изображение </summary>
        [Key]
        [Display(Name = "ID_Img")]
        public int IdImg { get; set; }
        /// <summary> Название файла с типом изображением (.jpg, .png и т. д.) </summary>
        public string? FileName { get; set; } = null!;
        /// <summary> Описание изображения (ключ слова) </summary>
        public string Title { get; set; } = null!;
        /// <summary> Изображение в байтах </summary>
        public byte[] DataImg { get; set; }
    }
}
