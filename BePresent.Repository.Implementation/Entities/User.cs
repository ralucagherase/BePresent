using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BePresent.Repository.Implementation.Entities
{
    public class User : Entity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(10)]
        [RegularExpression(@"^04\d{8}$", ErrorMessage = "That's not a valid mobile number")]
        public string Mobile { get; set; }
        [MaxLength(20)]
        public string StudentId { get; set; }
        [MaxLength(20)]
        public string StaffId { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Enrolment> Enrolments { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
