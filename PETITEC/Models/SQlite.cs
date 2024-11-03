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

        // Guardar el usuario
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

        // Obtener la mascota por UsuarioId
        public static Mascota ObtenerMascotaPorUsuarioId(int usuarioId)
        {
            lock (locker)
            {
                return database.Table<Mascota>().FirstOrDefault(m => m.UsuarioId == usuarioId);
            }
        }

        // Obtener usuario por correo y contraseña
        public static Usuario GetUsuarioPorCorreoYContraseña(string correo, string contraseña)
        {
            lock (locker)
            {
                return database.Table<Usuario>().FirstOrDefault(x => x.Correo == correo && x.Contraseña == contraseña);
            }
        }

        // Obtener la última mascota ingresada
        public static Mascota GetUltimaMascota()
        {
            lock (locker)
            {
                return database.Table<Mascota>().OrderByDescending(x => x.Id).FirstOrDefault();
            }
        }

        // Guardar o actualizar datos de la mascota
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

        // Método para sincronizar la actividad con Google Fit
        public static void SincronizarActividadConGoogleFit(List<Actividad> actividades)
        {
            lock (locker)
            {
                foreach (var actividad in actividades)
                {
                    var actividadExistente = database.Table<Actividad>().FirstOrDefault(a => a.Fecha.Date == actividad.Fecha.Date && a.MascotaId == actividad.MascotaId);
                    if (actividadExistente != null)
                    {
                        // Actualizar si ya existe
                        actividadExistente.Pasos = actividad.Pasos;
                        actividadExistente.Distancia = actividad.Distancia;
                        database.Update(actividadExistente);
                    }
                    else
                    {
                        // Insertar si es nuevo
                        database.Insert(actividad);
                    }
                }
            }
        }

        // Verificar si Google Fit está conectado
        public static bool IsGoogleFitConnected()
        {
            return Xamarin.Essentials.Preferences.Get("IsGoogleFitConnected", false);
        }

        // Método para actualizar la conexión con Google Fit
        public static void SetGoogleFitConnectionStatus(bool isConnected)
        {
            Xamarin.Essentials.Preferences.Set("IsGoogleFitConnected", isConnected);
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
