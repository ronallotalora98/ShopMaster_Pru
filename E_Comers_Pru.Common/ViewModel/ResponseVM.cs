using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.ViewModel
{
    public class ResponseVM
    {
        public bool Result { get; set; } = true;

        public bool IsError { get; set; } = false;

        public string? Message { get; set; }

        public object? Element { get; set; }
    }
}
