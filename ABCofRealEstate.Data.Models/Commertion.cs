using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Commertion : IRealEstateObject, IBuilding
    {
        /// <summary> Идентификатор объекта коммерции </summary>
        [Key]
        [Display(Name = "ID_Commertion")]
        public int IdCommertion { get; set; }
        /// <summary> Район </summary>
        public string? District { get; set; }
        /// <summary> Улица </summary>
        public string Street { get; set; }
        /// <summary> Ссылки на изображении объекта под коммерцию </summary>
        public string? URLImgs { get; set; }
        /// <summary> Описание комерции </summary>
        public string Description { get; set; }
        /// <summary> Цена </summary>
        public int Price { get; set; }
        /// <summary> Идентификатор агента недвижимости </summary>
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        /// <summary> Количество комнат </summary>
        public int CountRooms { get; set; }
        /// <summary> На каком этаже находится объект под комерцию </summary>
        public int LocatedFloorApartament { get; set; }
        /// <summary> Количество этаже в здании </summary>
        public int CountFloorsHouse { get; set; }
        /// <summary> Угловая? </summary>
        public bool IsCorner { get; set; }
        /// <summary> Материал здания </summary>
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Площадь помещения </summary>
        public int RoomArea { get; set; }
        /// <summary> Тип продажи (продажа/сдача в аренду) </summary>
        public EnumTypeSale TypeSale { get; set; }
        /// <summary> Населённый пункт </summary>
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
    }
}
