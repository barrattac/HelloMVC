using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserService
    {
        public UsersVM GetUsers()
        {
            UserDAO dao = new UserDAO();
            List<User> users = dao.GetAllUsers();
            UsersVM usersVM = new UsersVM();
            foreach (User user in users)
            {
                UserVM userVM = new UserVM();
                userVM.ID = user.ID;
                userVM.Email = user.Email;
                usersVM.Users.Add(userVM);
            }
            return usersVM;
        }
        public bool CreateUser(UserFM userFM)
        {
            if (IsValidUser(userFM))
            {
                UserDAO dao = new UserDAO();
                User user = new User();
                user.Email = userFM.Email;
                user.Password = RngPass();
                //TODO email temp pass to user
                dao.CreateUser(user);
                return true;
            }
            return false;
        }
        static string RngPass()
        {
            Random rng = new Random();
            string pass = "";
            for (int i = 0; i < 8; i++)
            {
                int dec = rng.Next(3);
                switch (dec)
                {
                    case 1: // number
                        pass = pass + Convert.ToChar(rng.Next(48, 58));
                        break;
                    case 2: // upper case
                        pass = pass + Convert.ToChar(rng.Next(65, 91));
                        break;
                    case 3:  // lower case
                        pass = pass + Convert.ToChar(rng.Next(97, 123));
                        break;
                }
            }
            return pass;
        }
        public bool IsValidUser(UserFM user)
        {
            UserDAO dao = new UserDAO();
            if (user.Email != null && user.Email.Length > 5 && dao.GetUserByEmail(user.Email) == null)
            {
                return true;
            }
            return false;
        }

        public UserFM GetUserFM(int ID)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(ID);
            UserFM userFM = new UserFM(user);
            return userFM;
        }

        public void UpdateUser(UserFM userFM)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(userFM.ID);
            user.Email = userFM.Email;
            dao.UpdateUser(user);
        }
    }
}
