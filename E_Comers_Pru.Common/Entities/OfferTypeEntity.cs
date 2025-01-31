using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_TIPO_PROMOCION")]
    public class OfferTypeEntity
    {
        [Key, Column("TPR_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("TPR_DESCRIPCION")]
        public string Description { get; set; }
        [Column("TPR_CODIGO")]
        public string Code { get; set; }

        public virtual IList<OfferEntity> Offers { get; set; }
    }
}
