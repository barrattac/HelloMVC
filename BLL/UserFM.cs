using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserFM
    {
        public string Email { get; set; }
        public int ID { get; set; }
        public UserFM(User user)
        {
            this.Email = user.Email;
            this.ID = user.ID;
        }
        public UserFM()
        {

        }
    }
}
