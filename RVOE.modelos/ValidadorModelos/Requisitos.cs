using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.ValidadorModelos.modelos;

public partial class Requisitos
{
    [Key]
    public Guid RequisitosId { get; set; }

    public Guid EscuelaId { get; set; }

    public bool Licenciatura { get; set; }

    public bool Funcionando { get; set; }

    [StringLength(50)]
    public string CedulaFuncionamiento { get; set; } = null!;

    [StringLength(50)]
    public string Periodos { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaUltimaActualizacion { get; set; }

    [ForeignKey("EscuelaId")]
    [InverseProperty("Requisitos")]
    public virtual Escuelas Escuela { get; set; } = null!;
}
