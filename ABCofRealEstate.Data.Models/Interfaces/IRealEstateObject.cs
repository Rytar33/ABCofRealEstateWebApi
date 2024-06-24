using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Entities;

namespace ABCofRealEstate.Data.Models.Interfaces
{
    /// <summary> Интерфейс объекта под недвижимость </summary>
    public interface IRealEstateObject
    {
        /// <summary> Идентификатор объекта </summary>
        public Guid Id { get; init; }
        /// <summary> Район </summary>
        public string? District { get; init; }
        /// <summary> Улица </summary>
        public string? Street { get; init; }
        /// <summary> Описание объекта </summary>
        public string? Description { get; init; }
        /// <summary> Цена за объект(или за арендную плату) </summary>
        public int Price { get; init; }
        /// <summary> Идентификатор агента недвижимости </summary>
        public Guid? EmployeeId { get; init; }
        /// <summary> Модель работника за которым закреплён объект </summary>
        public Employee? Employee { get; init; }
        /// <summary> Город/сельская местность в котором находится объект </summary>
        public EnumLocality Locality { get; init; }
        /// <summary> Тип продажи (продажа/сдача в аренду) </summary>
        public EnumTypeSale TypeSale { get; init; }
        /// <summary> Дата и время публикации объекта </summary>
        public DateTime DateTimePublished { get; init; }
        /// <summary> Актуальна ли публикации </summary>
        public bool IsActual { get; }
        public Guid SourceRealEstateObjectId { get; init; }
        public SourceRealEstateObject? SourceRealEstateObject { get; init; }
        public string ImportantInformation { get; init; }
        /// <summary> Широта </summary>
        public decimal Latitude { get; init; }
        
        /// <summary> Долгота </summary>
        public decimal Longitude { get; init; }
    }
}