using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Common.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.IService
{
    public interface ILoginService
    {
        Task<ResponseVM> LoginBackoffice(LoginRequestVM vm);

        Task<ResponseVM> RenovateToken(RenovateTokenRequestVM vm);
    }
}
