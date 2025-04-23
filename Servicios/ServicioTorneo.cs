using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorneosITM.Models;

namespace TorneosITM.Servicios
{
    public class ServicioTorneo
    {
        private TorneoITMEntities DBTorneoITM = new TorneoITMEntities();
        
        public List<Torneo> ObtenerTorneoPorTipo(string tipoTorneo)
        {
            return DBTorneoITM.Torneos.Where(t => t.TipoTorneo == tipoTorneo).ToList();
        }

        public List<Torneo> ObtenerTorneosPorNombre(string nombreTorneo)
        {
            return DBTorneoITM.Torneos.Where(t => t.NombreTorneo.Contains(nombreTorneo)).ToList();
        }

        public List<Torneo> ObtenerTorneosPorFecha(DateTime fechaTorneo)
        {
            return DBTorneoITM.Torneos.Where(t => t.FechaTorneo == fechaTorneo).ToList();
        }

        public string AgregarTorneo(Torneo torneo)
        {
            try
            {
                DBTorneoITM.Torneos.Add(torneo);
                DBTorneoITM.SaveChanges();
                return "Torneo agregado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al agregar el torneo: " + ex.Message;
            }
        }

        public string ActualizarTorneo(Torneo torneo)
        {
            try
            {
                Torneo torneoExistente = DBTorneoITM.Torneos.FirstOrDefault(t => t.idTorneos == torneo.idTorneos);
                if (torneoExistente != null)
                {
                    torneoExistente.idAdministradorITM = torneo.idAdministradorITM;
                    torneoExistente.TipoTorneo = torneo.TipoTorneo;
                    torneoExistente.NombreTorneo = torneo.NombreTorneo;
                    torneoExistente.NombreEquipo = torneo.NombreEquipo;
                    torneoExistente.ValorInscripcion = torneo.ValorInscripcion;
                    torneoExistente.FechaTorneo = torneo.FechaTorneo;
                    torneoExistente.Integrantes = torneo.Integrantes;
                    DBTorneoITM.SaveChanges();
                    return "Torneo actualizado correctamente.";
                }
                else
                {
                    return "El torneo no existe.";
                }
            }
            catch (Exception ex)
            {
                return "Error al actualizar el torneo: " + ex.Message;
            }
        }

        public string EliminarTorneo(int idTorneo)
        {
            try
            {
                Torneo torneo = DBTorneoITM.Torneos.FirstOrDefault(t => t.idTorneos == idTorneo);
                if (torneo != null)
                {
                    DBTorneoITM.Torneos.Remove(torneo);
                    DBTorneoITM.SaveChanges();
                    return "Torneo eliminado correctamente.";
                }
                else
                {
                    return "El torneo no existe.";
                }
            }
            catch (Exception ex)
            {
                return "Error al eliminar el torneo: " + ex.Message;
            }
        }
    }
}