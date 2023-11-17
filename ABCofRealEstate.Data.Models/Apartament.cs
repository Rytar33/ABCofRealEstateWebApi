using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Apartament : IRealEstateObject, IBuilding
    {
        /// <summary> Идентификатор квартиры </summary>
        [Key]
        [Display(Name = "ID_Apartament")]
        public int IdApartament { get; set; }
        /// <summary> Количество комнат </summary>
        public int CountRooms { get; set; }
        /// <summary> Район </summary>
        public string? District { get; set; }
        /// <summary> Улица </summary>
        public string Street { get; set; }
        /// <summary> Номер дома </summary>
        public string NumberHouse { get; set; }
        /// <summary> Состояние квартиры </summary>
        public EnumConditionHouse ConditionHouse { get; set; }
        /// <summary> Площадь(в кв м) Жилая </summary>
        public int LivingSpace { get; set; } = 0;
        /// <summary> Площадь(в кв м) Общая </summary>
        public int TotalArea { get; set; } = 0;
        /// <summary> Площадь(в кв м) Кухни </summary>
        public int KitchenArea { get; set; } = 0;
        /// <summary> Этажность дома </summary>
        public int CountFloorsHouse { get; set; }
        /// <summary> Квартира находится на этаже... </summary>
        public int LocatedFloorApartament { get; set; }
        /// <summary> Угловая? </summary>
        public bool IsCorner { get; set; }
        /// <summary> Количество балконов </summary>
        public int CountBalcony { get; set; }
        /// <summary> Из какого материала построен дом </summary>
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Ссылки на изображении квартиры </summary>
        public string? URLImgs { get; set; }
        /// <summary> Описание квартиры </summary>
        public string Description { get; set; }
        /// <summary> Цена за квартиру </summary>
        public int Price { get; set; }
        /// <summary> Индентификатор агента недвижимости </summary>
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        /// <summary> Тип продажи (продаётся/сдаётся в аренду) </summary>
        public EnumTypeSale TypeSale { get; set; }
        /// <summary> Населённый пункт </summary>
        public EnumLocality Locality { get; set; }
    }
}