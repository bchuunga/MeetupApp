using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetup.Core.Data.Entities
{
    public class Meetup
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Organizer { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }

        public virtual Location Location { get; set; }

        public virtual List<Lecture> Lectures { get; set; }
        public int? CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }
}
