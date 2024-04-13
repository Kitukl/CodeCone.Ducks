using System.ComponentModel.DataAnnotations;

namespace CodeCone.Ducks.Models
{
    public class Ticket
    {
            public int TicketId { get; set; }

            [Required]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Status")]
            public bool Status { get; set; }

            [Required]
            [Display(Name = "Priority")]
            public string Priority { get; set; }

            [Required]
            [Display(Name = "Type")]
            public string Type { get; set; }

            [Required]
            [Display(Name = "Submitter")]
            public string Submitter { get; set; }

            [Required]
            [Display(Name = "Assignee")]
            public string Assignee { get; set; }

            [Required]
            [Display(Name = "Created At")]
            public DateTime CreatedAt { get; set; }

            [Required]
            [Display(Name = "Updated At")]
            public DateTime UpdatedAt { get; set; }
        }
    
}
