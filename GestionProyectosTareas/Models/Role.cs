using System;
using System.Collections.Generic;

namespace GestionProyectosTareas.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? NombreDelRol { get; set; }

        public virtual ICollection<Usuario> Users { get; set; }
    }
}
