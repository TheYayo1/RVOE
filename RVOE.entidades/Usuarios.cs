using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVOE.entidades;

//[Microsoft.EntityFrameworkCore.Index("Correo", Name = "UQ__Usuarios__60695A19F02DD7B0", IsUnique = true)]
public partial class Usuarios
{
    [Key]
    public Guid UsuarioId { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    public string? ApellidoPaterno { get; set; }

    [StringLength(50)]
    public string? ApellidoMaterno { get; set; }

    [StringLength(100)]
    public string Correo { get; set; } = null!;

    [StringLength(200)]
    public string ContrasenaHash { get; set; } = null!;

    public Guid RolId { get; set; }

    public bool Activo { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Roles Rol { get; set; } = null!;
}
