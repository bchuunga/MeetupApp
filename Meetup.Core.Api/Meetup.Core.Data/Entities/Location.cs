using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetup.Core.Data.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(6)")]
        public string PostCode { get; set; }

        public virtual Meetup Meetup { get; set; }
        public int MeetupId { get; set; }
    }
}
