using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.ValidadorModelos.modelos;

public partial class PlanesProgramas
{
    [Key]
    public Guid PlanId { get; set; }

    public Guid EscuelaId { get; set; }

    [StringLength(100)]
    public string NombrePlan { get; set; } = null!;

    [StringLength(50)]
    public string CicloEscolar { get; set; } = null!;

    [StringLength(50)]
    public string RVOEActual { get; set; } = null!;

    [StringLength(200)]
    public string? MotivoCambioRVOE { get; set; }

    [StringLength(50)]
    public string? ClaveDGP { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaAltaDGP { get; set; }

    [StringLength(50)]
    public string ClaveSIRVOES { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaAltaSIRVOES { get; set; }

    [ForeignKey("EscuelaId")]
    [InverseProperty("PlanesProgramas")]
    public virtual Escuelas Escuela { get; set; } = null!;

    [InverseProperty("Plan")]
    public virtual ICollection<HistoricosRVOE> HistoricosRVOE { get; set; } = new List<HistoricosRVOE>();
}
