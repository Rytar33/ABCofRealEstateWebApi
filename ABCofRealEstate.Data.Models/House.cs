using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class House : IRealEstateObject, IBuilding
    {
        /// <summary> Идентификатор дома </summary>
        [Key]
        [Display(Name = "ID_House")]
        public int IdHouse { get; set; }
        /// <summary> Район </summary>
        public string? District { get; set; }
        /// <summary> Улица </summary>
        public string Street { get; set; }
        /// <summary> Изображения дома </summary>
        public string? URLImgs { get; set; }
        /// <summary> Описание дома </summary>
        public string Description { get; set; }
        /// <summary> Цена дома </summary>
        public int Price { get; set; }
        /// <summary> Идентификатор агента недвижимости </summary>
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        /// <summary> Количество комнат </summary>
        public int CountRooms { get; set; }
        /// <summary> Этаж в доме </summary>
        public int LocatedFloorApartament { get; set; }
        /// <summary> Количество этажей в доме </summary>
        public int CountFloorsHouse { get; set; }
        /// <summary> Угловая? </summary>
        public bool IsCorner { get; set; }
        /// <summary> Материал дома </summary>
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Состояние дома </summary>
        public EnumConditionHouse? ConditionHouse { get; set; }
        /// <summary> Площадь(в кв. м.) жилая </summary>
        public int LivingSpace { get; set; } = 0;
        /// <summary> Площадь(в кв. м.) общая </summary>
        public int TotalArea { get; set; } = 0;
        /// <summary> Площадь(в кв. м.) кухни </summary>
        public int KitchenArea { get; set; } = 0;
        /// <summary> Площадь(в кв. м.) участка</summary>
        public double Area { get; set; }
        /// <summary> Площадь(сот.) огорода </summary>
        public int GardenSot { get; set; }
        /// <summary> Тип продажи (продажа/сдача в аренду) </summary>
        public EnumTypeSale TypeSale { get; set; }
        /// <summary> Населённый пункт </summary>
        public EnumLocality Locality { get; set; }
    }
}
