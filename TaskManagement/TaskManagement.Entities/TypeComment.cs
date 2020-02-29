using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Entities
{
  public  class TypeComment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
