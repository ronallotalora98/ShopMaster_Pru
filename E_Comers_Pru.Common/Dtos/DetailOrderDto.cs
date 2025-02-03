using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Dtos
{
    public class DetailOrderDto
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int UnitPrice { get; set; }

    }
}
