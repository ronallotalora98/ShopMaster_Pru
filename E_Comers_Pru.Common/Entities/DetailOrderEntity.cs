using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_DETALLE_ORDEN")]
    public class DetailOrderEntity
    {
        [Key, Column("DOR_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("DOR_ORDEN_ID"), ForeignKey("DOR_ORDEN_ID")]
        public int OrdenId { get; set; }
        [Column("DOR_PRODUCTO_ID"), ForeignKey("DOR_PRODUCTO_ID")]
        public int ProductId { get; set; }
        [Column("DOR_CANTIDAD")]
        public int Amount { get; set; }
        [Column("DOR_PRECIO_UNITARIO")]
        public int UnitPrice { get; set; }

        public virtual OrdenEntity Orden { get; set; }
        public virtual ProductEntity Product { get; set; }


    }
}
