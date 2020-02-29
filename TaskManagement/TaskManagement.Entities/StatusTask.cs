using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Entities
{
  public  class StatusTask 
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
