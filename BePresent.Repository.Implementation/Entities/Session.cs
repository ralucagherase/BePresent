using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BePresent.Repository.Implementation.Entities
{
    public class Session : Entity
    {
        public DateTime DateTime { get; set; }
        public string RoomNumber { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [ForeignKey("RoomNumber")]
        public Location Location { get; set; }
    }
}
