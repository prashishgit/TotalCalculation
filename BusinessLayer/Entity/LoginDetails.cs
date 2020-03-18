using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class LoginDetails
    {
        public int LoginDetailId { get; set; }
        public int UserId { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
