using System;
using System.Collections.Generic;
using System.Text;

namespace BePresent.Repository.Implementation.Entities
{
    public class Enrolment : Entity
    {
        public string Status { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public User User { get; set; }
        public Class Class { get; set; }
    }
}
