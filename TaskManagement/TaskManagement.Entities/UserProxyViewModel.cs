using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Web.Models
{
    public class UserProxyViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsChecked { get; set; }
    }
}
