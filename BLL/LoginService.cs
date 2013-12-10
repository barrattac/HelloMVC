using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LoginService
    {
        public UserVM Login(LoginFM login)
        {
            UserVM userVM = null;
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByEmail(login.Email);
            if (user != null && user.Password == login.Password)
            {
                userVM = new UserVM();
                userVM.ID = user.ID;
                userVM.Email = user.Email;
            }
            return userVM;
        }
    }
}