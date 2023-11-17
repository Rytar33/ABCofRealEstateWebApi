using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Hostel : IRealEstateObject, IBuilding
    {
        /// <summary> Идентификатор общежития </summary>
        [Key]
        [Display(Name = "ID_Hostel")]
        public int IdHostel { get; set; }
        /// <summary> Район </summary>
        public string? District { get; set; }
        /// <summary> Улица </summary>
        public string Street { get; set; }
        /// <summary> Изображения общежития </summary>
        public string? URLImgs { get; set; }
        /// <summary> Площадь(в кв м) Жилая </summary>
        public int LivingSpace { get; set; } = 0;
        /// <summary> Площадь(в кв м) Общая </summary>
        public int TotalArea { get; set; } = 0;
        /// <summary> Площадь(в кв м) Кухни </summary>
        public int KitchenArea { get; set; } = 0;
        /// <summary> Описание общежития </summary>
        public string Description { get; set; }
        /// <summary> Цена </summary>
        public int Price { get; set; }
        /// <summary> Идентификатор агента недвижимости </summary>
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        /// <summary> Населённый пункт </summary>
        public EnumLocality Locality { get; set; }
        /// <summary> Состояние общежития </summary>
        public EnumConditionHouse ConditionHouse { get; set; }
        /// <summary> Количество комнат </summary>
        public int CountRooms { get; set; }
        /// <summary> Этаж на котором находится номер общежития </summary>
        public int LocatedFloorApartament { get; set; }
        /// <summary> Угловая? </summary>
        public bool IsCorner { get; set; }
        /// <summary> Материал здания </summary>
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Тип продажи (покупка/сдача в аренду) </summary>
        public EnumTypeSale TypeSale { get; set; }
    }
}
