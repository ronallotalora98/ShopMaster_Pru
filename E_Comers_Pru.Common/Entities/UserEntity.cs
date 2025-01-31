using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Entities
{
    [Table("SM_USUARIO")]
    public class UserEntity
    {
        [Key, Column("USU_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("USU_NOMBRE")]
        public string Name { get; set; }
        [Column("USU_CORREO")]
        public string Email { get; set; }
        [Column("USU_CLAVE")]
        public string Password { get; set; }

        [Column("USU_ROL_ID"), ForeignKey("USU_ROL_ID")]
        public int RolId { get; set; }
        public virtual RolEntity Rol { get; set; }

        public virtual IList<OrdenEntity> PurchaseHistory { get; set; }
    }
}
