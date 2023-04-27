using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities
{
    [Table("Department")]
    public partial class Department
    {
        public Department()
        {
            DepartmentEmployees = new HashSet<DepartmentEmployee>();
        }

        [Key]
        public long RecId { get; set; }
        [StringLength(128)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        [InverseProperty("DepartmentRec")]
        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
