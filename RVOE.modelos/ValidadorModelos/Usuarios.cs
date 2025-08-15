using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.modelos.ValidadorModelos;

public partial class Usuarios
{
    [Key]
    public Guid UsuarioId { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(30)]
    public string ApellidoPaterno { get; set; } = null!;

    [StringLength(30)]
    public string ApellidoMaterno { get; set; } = null!;

    [StringLength(100)]
    public string? Correo { get; set; }

    [StringLength(255)]
    public string Contraseña { get; set; } = null!;

    public Guid RolId { get; set; }

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Roles Rol { get; set; } = null!;
}
