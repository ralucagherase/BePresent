using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BePresent.Repository.Implementation.Entities
{
    public class Card:Entity
    {
        [Key]
        public string CardNo { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
