using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TareasApp.Models
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string FechaHora { get; set; }
        public string Prioridad { get; set; }

    }
}
