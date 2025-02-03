using E_Comers_Pru.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.ViewModel.Response
{
    public class InvoiceResponseVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrdenDate { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }
        public string NameUser { get; set; }
        public List<DetailOrderDto> Details { get; set; }
    }
}
