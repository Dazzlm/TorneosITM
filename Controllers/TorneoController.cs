using TorneosITM.Models;
using TorneosITM.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ParqueDivITM.Controllers
{
    [RoutePrefix("api/Torneo")]
    public class TorneoController : ApiController
    {

        [HttpGet]
        [Route("ConsultarPorTipo")]
        public List<Torneo> ConsultarTorneoPorTipo(string tipoTorneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.ObtenerTorneoPorTipo(tipoTorneo);
        }

        [HttpGet]
        [Route("ConsultarPorNombre")]
        public List<Torneo> ConsultarTorneoPorNombre(string nombreTorneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.ObtenerTorneosPorNombre(nombreTorneo);
        }

        [HttpGet]
        [Route("ConsultarPorFecha")]
        public List<Torneo> ConsultarTorneoPorFecha(DateTime fechaTorneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.ObtenerTorneosPorFecha(fechaTorneo);
        }

        [HttpPost]
        [Route("Agregar")]
        public string Agregar([FromBody] Torneo torneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.AgregarTorneo(torneo);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.ActualizarTorneo(torneo);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idTorneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.EliminarTorneo(idTorneo);
        }
    }
}