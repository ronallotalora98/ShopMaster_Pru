using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_PROMOCION")]
    public class OfferEntity
    {
        [Key, Column("PRO_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("PRO_DESCRIPCION")]
        public string Description { get; set; }
        [Column("PRO_TIPO_PROMOCION_ID"), ForeignKey("PRO_TIPO_PROMOCION_ID")]
        public int OfferTypeId { get; set; }
        [Column("PRO_DESCUENTO")]
        public int Discount { get; set; }
        [Column("PRO_CONDICION")]
        public string Condition { get; set; }
        [Column("PRO_FECHA_INICIO")]
        public DateTime StartDate { get; set; }
        [Column("PRO_FECHA_FIN")]
        public DateTime EndDate { get; set; }
        public virtual OfferTypeEntity OfferType { get; set; }

    }
}
