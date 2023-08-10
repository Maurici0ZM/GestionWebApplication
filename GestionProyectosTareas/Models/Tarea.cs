using System;
using System.Collections.Generic;

namespace GestionProyectosTareas.Models
{
    public partial class Tarea
    {
        public Tarea()
        {
            Anexos = new HashSet<Anexo>();
        }

        public int Id { get; set; }
        public int? ProyectoId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Título { get; set; }
        public string? Descripción { get; set; }
        public int? NivelDificultad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual Proyecto? Proyecto { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Anexo> Anexos { get; set; }
    }
}
