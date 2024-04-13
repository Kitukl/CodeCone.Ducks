using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("Ticket")]
public partial class Ticket
{
    [Key]
    public int TicketId { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    [Required]
    [StringLength(20)]
    public string Type { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Phone { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string Card { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    public int PersonId { get; set; }

    public bool IsActual { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Tickets")]
    public virtual Person Person { get; set; }
}
