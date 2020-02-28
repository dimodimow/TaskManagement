using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Entities.Base.Contracts
{
    public interface IDeletable
    {
        DateTime? DeletedOn { get; set; }
        bool IsDeleted { get; set; }
    }
}
