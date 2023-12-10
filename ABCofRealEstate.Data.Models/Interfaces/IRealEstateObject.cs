using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models.Interfaces
{
    public interface IRealEstateObject
    {
        /// <summary> Район </summary>
        public string? District { get; set; }
        /// <summary> Улица </summary>
        public string? Street { get; set; }
        /// <summary> Идентификаторы изображении объекта </summary>
        public string? IdsImg { get; set; }
        /// <summary> Описание объекта </summary>
        public string? Description { get; set; }
        /// <summary> Цена за объект(или за арендную плату) </summary>
        public int Price { get; set; }
        /// <summary> Идентификатор агента недвижимости </summary>
        public int? IdEmployee { get; set; }
        /// <summary> Модель работника за которым закреплён объект </summary>
        public Employee? Employee { get; set; }
        /// <summary> Город/сельская местность в котором находится объект </summary>
        public EnumLocality Locality { get; set; }
        /// <summary> Дата и время публикации объекта </summary>
        public DateTime DateTimePublished { get; set; }
        /// <summary> Актуальна ли публикации </summary>
        public bool IsActual { get; set; }
    }
}