using System;
using System.Collections.Generic;

namespace GestionProyectosTareas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ParticipacionProyectos = new HashSet<ParticipacionProyecto>();
            Tareas = new HashSet<Tarea>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public string? Rol { get; set; }

        public virtual ICollection<ParticipacionProyecto> ParticipacionProyectos { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
