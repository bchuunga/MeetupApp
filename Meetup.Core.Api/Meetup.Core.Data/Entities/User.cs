using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetup.Core.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role  { get; set; }
    }
}
