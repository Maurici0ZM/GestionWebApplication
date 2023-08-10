using System;
using System.Collections.Generic;

namespace GestionProyectosTareas.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            ParticipacionProyectos = new HashSet<ParticipacionProyecto>();
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string? Título { get; set; }
        public string? Descripción { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual ICollection<ParticipacionProyecto> ParticipacionProyectos { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
