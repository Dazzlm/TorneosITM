using TorneosITM.Servicios;
using TorneosITM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TorneosITM.Controllers
{
    [RoutePrefix("api/Login")]
 
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar([FromBody] Login login)
        {
            ServicioLogin _login = new ServicioLogin();
            _login.login = login;
            return _login.Ingresar();
        }
    }
}