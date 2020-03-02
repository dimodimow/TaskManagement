using System.Collections.Generic;

namespace TaskManagement.Entities
{
  public  class StatusTask 
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
