using System;
using System.Collections.Generic;

namespace GestionProyectosTareas.Models
{
    public partial class Anexo
    {
        public int Id { get; set; }
        public int? TareaId { get; set; }
        public string? NombreArchivo { get; set; }
        public string? RutaArchivo { get; set; }

        public virtual Tarea? Tarea { get; set; }
    }
}
