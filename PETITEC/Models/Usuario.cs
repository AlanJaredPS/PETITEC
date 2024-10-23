using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PETITEC.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña {  get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
