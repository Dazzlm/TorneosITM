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
        [Route("ConsultarTodos")]
        public List<Torneo> ConsultarTodos()
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.ObtenerTorneos();
        }

        [HttpGet]
        [Route("Consultar/{idTorneo}")]
        public Torneo Consultar(int idTorneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.ObtenerTorneo(idTorneo);
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
        [Route("Eliminar/{idTorneo}")]
        public string Eliminar(int idTorneo)
        {
            ServicioTorneo servicioTorneo = new ServicioTorneo();
            return servicioTorneo.EliminarTorneo(idTorneo);
        }
    }
}