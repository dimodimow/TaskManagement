using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Entities.Base.Contracts
{
   public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}
