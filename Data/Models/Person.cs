using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("Person")]
public partial class Person
{
    [Key]
    public int PersonId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string SurName { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string UserName { get; set; }

    public int Age { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
