﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorneosITM.Models;

namespace TorneosITM.Servicios
{
    public class ServicioTorneo
    {
        private DBTorneoITMEntities dbTorneoITM = new DBTorneoITMEntities();

        public List<Torneo> ObtenerTorneosPorNombre(string nombreTorneo)
        {
            return dbTorneoITM.Torneos.Where(t => t.NombreTorneo == nombreTorneo).ToList();
        }
        public List<Torneo> ObtenerTorneosPorTipo(string tipoTorneo)
        {
            return dbTorneoITM.Torneos.Where(t => t.TipoTorneo == tipoTorneo).ToList();
        }
        public List<Torneo> ObtenerTorneosPorFecha(DateTime fechaTorneo)
        {
            return dbTorneoITM.Torneos.Where(t => t.FechaTorneo == fechaTorneo).ToList();
        }

        public string AgregarTorneo(Torneo torneo)
        {
            try
            {
                dbTorneoITM.Torneos.Add(torneo);
                dbTorneoITM.SaveChanges();
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
                Torneo torneoExistente = dbTorneoITM.Torneos.FirstOrDefault(t => t.idTorneos == torneo.idTorneos);
                if (torneoExistente != null)
                {
                    torneoExistente.idAdministradorITM = torneo.idAdministradorITM;
                    torneoExistente.TipoTorneo = torneo.TipoTorneo;
                    torneoExistente.NombreTorneo = torneo.NombreTorneo;
                    torneoExistente.NombreEquipo = torneo.NombreEquipo;
                    torneoExistente.ValorInscripcion = torneo.ValorInscripcion;
                    torneoExistente.FechaTorneo = torneo.FechaTorneo;
                    torneoExistente.Integrantes = torneo.Integrantes;
                    dbTorneoITM.SaveChanges();
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
                Torneo torneo = dbTorneoITM.Torneos.FirstOrDefault(t => t.idTorneos == idTorneo);
                if (torneo != null)
                {
                    dbTorneoITM.Torneos.Remove(torneo);
                    dbTorneoITM.SaveChanges();
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