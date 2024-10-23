using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using Xamarin.Forms;
using PETITEC.Vistas;

namespace PETITEC.Models
{
    public class SQlite
    {
        private static SQLiteConnection database;
        private static readonly object locker = new object();

        public SQlite()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "petitec.db3");
            database = new SQLiteConnection(dbPath);

            // Crear las tablas si no existen
            database.CreateTable<Mascota>();
            database.CreateTable<Usuario>();
            database.CreateTable<Actividad>(); // Tabla Actividad
        }

        // Métodos para guardar y obtener datos de Mascota

        public static int DatosMascota(Mascota mascota) 
        {
            lock (locker)
            {
                if (mascota.Id != 0)
                {
                    database.Update(mascota);
                    return mascota.Id;
                }
                else
                {
                    return database.Insert(mascota);
                }
            }
        }

        public static Mascota ObtenerMascota(int id)
        {
            lock (locker)
            {
                return database.Table<Mascota>().FirstOrDefault(x => x.Id == id);
            }
        }

        public static int SaveActividad(Actividad actividad)
        {
            lock (locker)
            {
                if (actividad.Id != 0)
                {
                    database.Update(actividad);
                    return actividad.Id;
                }
                else
                {
                    return database.Insert(actividad);
                }
            }
        }
        public static Actividad GetActividadPorFecha(int mascotaId, DateTime fecha)
        {
            lock (locker)
            {
                return database.Table<Actividad>().FirstOrDefault(x => x.MascotaId == mascotaId && x.Fecha.Date == fecha.Date);
            }
        }

        public static List<Actividad> GetHistorialActividad(int mascotaId)
        {
            lock (locker)
            {
                return database.Table<Actividad>().Where(x => x.MascotaId == mascotaId).ToList();
            }
        }
    }
}
