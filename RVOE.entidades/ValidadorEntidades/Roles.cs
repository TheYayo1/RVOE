using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVOE.entidades.ValidadorEntidades;

public partial class Roles
{
    [Key]
    public Guid RolId { get; set; }

    [StringLength(20)]
    public string NombreRol { get; set; } = null!;

    [StringLength(150)]
    public string? Descripcion { get; set; }

    [InverseProperty("Rol")]
    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
