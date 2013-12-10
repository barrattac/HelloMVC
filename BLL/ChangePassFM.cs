using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChangePassFM
    {
        public int ID { get; set; }
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string ConfirmPass { get; set; }
        public ChangePassFM(User user)
        {
            this.ID = user.ID;
            this.CurrentPass = user.Password;
            this.NewPass = user.Password;
            this.ConfirmPass = user.Password;
        }
        public ChangePassFM()
        {
                
        }
    }
}
