using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BePresent.Repository.Implementation.Entities
{
    public class Attendance : Entity
    {
        public DateTime DateTime { get; set; }
        public Boolean? Verified { get; set; }
        public string CardNo { get; set; }
        public DateTime? SessionDateTime { get; set; }
        public string RoomNumber { get; set; }
        [ForeignKey("CardNo")]
        public Card Card { get; set; }
        [ForeignKey("SessionDateTime, RoomNumber")]
        public Session Session { get; set; }
    }
}
