using E_Comers_Pru.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.ViewModel.Request
{
    public class InvoiceRequestVM
    {
        public int UserId { get; set; }
        public int Total { get; set; }
        public List<DetailOrderDto> detailOrders { get; set; }
    }
}
