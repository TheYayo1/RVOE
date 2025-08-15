using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.modelos.ValidadorModelos;

public partial class EstatusEscuela
{
    [Key]
    public int EstatusId { get; set; }

    [StringLength(50)]
    public string NombreEstatus { get; set; } = null!;

    [InverseProperty("Estatus")]
    public virtual ICollection<Escuelas> Escuelas { get; set; } = new List<Escuelas>();
}
