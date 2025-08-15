using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVOE.entidades;

public partial class Roles
{
    [Key]
    public Guid RolId { get; set; }

    [StringLength(50)]
    public string NombreRol { get; set; } = null!;

    [InverseProperty("Rol")]
    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
