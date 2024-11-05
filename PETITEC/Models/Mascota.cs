using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PETITEC.Models
{
    public class Mascota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public double Peso { get; set; }
        public string Tamaño { get; set; }

        //Relacion con la tabla Usuario
        public int UsuarioId { get; set; }

    }
}
