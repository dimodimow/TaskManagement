using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Entities
{
   public class TypeTask 
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
