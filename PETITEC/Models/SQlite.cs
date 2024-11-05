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

        public static int SaveUsuario(Usuario usuario)
        {
            lock (locker)
            {
                if (usuario.Id != 0)
                {
                    database.Update(usuario);
                    return usuario.Id;
                }
                else
                {
                    return database.Insert(usuario);
                }
            }
        }

        public static Mascota ObtenerMascotaPorUsuarioId(int usuarioId)
        {
            lock (locker)
            {
                // Obtener la mascota asociada al usuario desde la base de datos
                return database.Table<Mascota>().FirstOrDefault(m => m.UsuarioId == usuarioId);
            }
        }

        public static Usuario GetUsuarioPorCorreoYContraseña(string correo, string contraseña)
        {
            lock (locker)
            {
                // Buscar un usuario con el correo y contraseña proporcionados
                return database.Table<Usuario>().FirstOrDefault(x => x.Correo == correo && x.Contraseña == contraseña);
            }
        }

        public static Mascota GetUltimaMascota()
        {
            lock (locker)
            {
                return database.Table<Mascota>().OrderByDescending(x => x.Id).FirstOrDefault();
            }
        }

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

        public static int UpdateMascota(Mascota mascota)
        {
            lock (locker)
            {
                return database.Update(mascota);
            }
        }

        public static Usuario GetUsuario(int id)
        {
            lock (locker)
            {
                return database.Table<Usuario>().FirstOrDefault(x => x.Id == id);
            }
        }

        public static Mascota ObtenerMascota(int id)
        {
            lock (locker)
            {
                return database.Table<Mascota>().FirstOrDefault(x => x.Id == id);
            }
        }

        public static Usuario GetUsuarioPorCorreo(string correo)
        {
            lock (locker)
            {
                return database.Table<Usuario>().FirstOrDefault(x => x.Correo == correo);
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
