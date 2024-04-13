using System.ComponentModel.DataAnnotations;

namespace CodeCone.Ducks.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname {  get; set; }

        [Required]  
        public string UserName { get; set; }

        [Required]

        public int Age { get; set; }

        [Required]

        public string Password { get; set; }


    }
}
