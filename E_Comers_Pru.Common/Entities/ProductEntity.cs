using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_PRODUCTO")]
    public class ProductEntity
    {
        [Key, Column("PRO_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("PRO_NOMBRE")]
        public string Name { get; set; }
        [Column("PRO_DESCRIPCION")]
        public string Description { get; set; }
        [Column("PRO_PRECIO")]
        public int Price { get; set; }
        [Column("PRO_CATEGORIA_ID"), ForeignKey("PRO_CATEGORIA_ID")]
        public int CategoryId { get; set; }
        [Column("PRO_IMAGEN")]
        public string Image { get; set; }
        [Column("PRO_INVENTARIO")]
        public int Inventory { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public virtual IList<DetailOrderEntity> detailOrders { get; set; }
    }
}
