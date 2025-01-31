using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_CATEGORIA")]
    public class CategoryEntity
    {
        [Key, Column("CAT_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("CAT_NOMBRE")]
        public string Name { get; set; }
        [Column("CAT_CODIGO")]
        public string Code { get; set; }
        public IList<ProductEntity> Products { get; set; }
    }
}
