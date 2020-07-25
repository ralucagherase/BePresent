using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BePresent.Repository.Implementation.Entities
{
    public class Role : Entity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
