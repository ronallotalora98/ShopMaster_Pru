using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_ROL")]
    public class RolEntity
    {
        [Key, Column("ROL_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("ROL_DESCRIPCION")]
        public string Description { get; set; }
        [Column("ROL_CODIGO")]
        public string Code { get; set; }
        public virtual IList<UserEntity> Usuarios { get; set; }
    }
}
