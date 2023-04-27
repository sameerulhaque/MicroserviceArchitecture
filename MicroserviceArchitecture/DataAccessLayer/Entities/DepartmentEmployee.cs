using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities
{
    public partial class DepartmentEmployee
    {
        [Key]
        public long RecId { get; set; }
        [Column("Department_RecId")]
        public long? DepartmentRecId { get; set; }
        [Column("Employe_RecId")]
        public long? EmployeRecId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        [ForeignKey("DepartmentRecId")]
        [InverseProperty("DepartmentEmployees")]
        public virtual Department? DepartmentRec { get; set; }
        [ForeignKey("EmployeRecId")]
        [InverseProperty("DepartmentEmployees")]
        public virtual Employe? EmployeRec { get; set; }
    }
}
