using System;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Entities.Base.Contracts;

namespace TaskManagement.Entities
{
    public class BaseEntity : IAuditable
    {
        int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get ; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
