using System.ComponentModel.DataAnnotations;

namespace CodeCone.Ducks.Models
{
    public class Jar
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Link { get; set; }

        public string ZvitLink { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
