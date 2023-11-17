using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetup.Core.Data.Entities
{
    public class Lecture
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Author { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Topic { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        public virtual Meetup Meetup { get; set; }
        public int MeetupId { get; set; }
    }
}
