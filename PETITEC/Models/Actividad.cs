using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PETITEC.Models
{
    public class Actividad
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int MascotaId { get; set; }
        public int Pasos {  get; set; }
        public float Distancia { get; set; }
        public DateTime Fecha { get; set; }

    }
}
