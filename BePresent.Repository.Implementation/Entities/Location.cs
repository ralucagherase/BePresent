using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BePresent.Repository.Implementation.Entities
{
    public class Location : Entity
    {
        [Key]
        public string RoomNumber { get; set; }
        [Required]
        public string ScannerNumber { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
