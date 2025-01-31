using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_ORDEN")]
    public class OrdenEntity
    {
        [Key, Column("ORD_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ORD_USER_ID"), ForeignKey("ORD_USER_ID")]
        public int UserId { get; set; }
        [Column("ORD_FECHA_ORDEN")]
        public DateTime OrdenDate { get; set; }
        [Column("ORD_ESTADO")]
        public string Status { get; set; }
        [Column("ORD_TOTAL")]
        public int Total { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual IList<DetailOrderEntity> DetailOrders { get; set; }
    }
}
