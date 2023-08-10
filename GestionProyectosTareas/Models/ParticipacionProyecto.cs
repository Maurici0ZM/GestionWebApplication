using System;
using System.Collections.Generic;

namespace GestionProyectosTareas.Models
{
    public partial class ParticipacionProyecto
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? ProyectoId { get; set; }

        public virtual Proyecto? Proyecto { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
