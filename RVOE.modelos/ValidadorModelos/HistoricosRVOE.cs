using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.ValidadorModelos.modelos;

public partial class HistoricosRVOE
{
    [Key]
    public Guid HistoricoRVOEId { get; set; }

    public Guid PlanId { get; set; }

    [StringLength(10)]
    public string RVOE { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [StringLength(200)]
    public string? Observaciones { get; set; }

    [ForeignKey("PlanId")]
    [InverseProperty("HistoricosRVOE")]
    public virtual PlanesProgramas Plan { get; set; } = null!;
}
