using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PattuSaree.ViewModel;

namespace PattuSaree.Service.Abstract
{
    public interface ISignUpService
    {
        void SingUp(UserMasterViewModel userVm);
    }
}
