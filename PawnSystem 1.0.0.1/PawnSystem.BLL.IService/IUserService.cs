using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnSystem.BLL.Model;
namespace PawnSystem.BLL.IService
{
    public interface IUserService
    {
        UserModel Login(string userName, string password);
    }
}
