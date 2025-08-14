using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.modelos;

public partial class Roles
{
    [Key]
    public Guid RolId { get; set; }

    [StringLength(50)]
    public string NombreRol { get; set; } = null!;

    [InverseProperty("Rol")]
    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
