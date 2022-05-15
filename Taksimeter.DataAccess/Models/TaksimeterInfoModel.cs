using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taksimeter.DataAccess.Models
{
    [Table("TAKSIMETER_INFO")]
    public class TaksimeterInfoModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("OPENING_PRICE")]
        public float OpeningPrice { get; set; }

        [Column("UNIT_DISTANCE_PRICE")]
        public float UnitDistancePrice { get; set; }

        [Column("MIN_PRICE")]
        public float MinPrice { get; set; }

        [Column("UNIT_TIME_PRICE")]
        public float UnitTimePrice { get; set; }
    }
}
