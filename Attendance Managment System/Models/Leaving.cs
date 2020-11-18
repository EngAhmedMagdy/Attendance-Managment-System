namespace Attendance_Managment_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Leaving")]
    public partial class Leaving
    {
        public int? RollNo { get; set; }

        [StringLength(50)]
        public string LeaveRequest { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? Time { get; set; }

        [Key]
        public int LeaveId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
