using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.ValidadorModelos.modelos;

public partial class Escuelas
{
    [Key]
    public Guid EscuelaId { get; set; }

    [StringLength(100)]
    public string NombreEscuela { get; set; } = null!;

    [StringLength(50)]
    public string NoExpendiente { get; set; } = null!;

    [StringLength(50)]
    public string CCT { get; set; } = null!;

    [StringLength(100)]
    public string RepresentanteLegal { get; set; } = null!;

    [StringLength(100)]
    public string SociedadCivil { get; set; } = null!;

    [StringLength(200)]
    public string Direccion { get; set; } = null!;

    [StringLength(50)]
    public string Municipio { get; set; } = null!;

    [StringLength(20)]
    public string Nivel { get; set; } = null!;

    [StringLength(50)]
    public string Modalidad { get; set; } = null!;

    [StringLength(50)]
    public string? PSU { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaIncorporacion { get; set; }

    public int EstatusId { get; set; }

    public bool? ConvenioSalud { get; set; }

    [StringLength(15)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    public string? Correo { get; set; }

    [StringLength(500)]
    public string? Observaciones { get; set; }

    [StringLength(50)]
    public Guid TipoEscuelaId { get; set; }

    [InverseProperty("Escuela")]
    public virtual ICollection<EnvioRecepcion> EnvioRecepcion { get; set; } = new List<EnvioRecepcion>();

    [ForeignKey("EstatusId")]
    [InverseProperty("Escuelas")]
    public virtual EstatusEscuela Estatus { get; set; } = null!;

    [InverseProperty("Escuela")]
    public virtual ICollection<PlanesProgramas> PlanesProgramas { get; set; } = new List<PlanesProgramas>();

    [InverseProperty("Escuela")]
    public virtual ICollection<Requisitos> Requisitos { get; set; } = new List<Requisitos>();
}
