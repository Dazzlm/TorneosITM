using TorneosITM.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorneosITM.Models;



namespace TorneosITM.Servicios
{
    public class ServicioLogin
    {
        public ServicioLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public DBTorneoITMEntities dbTorneoITM = new DBTorneoITMEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        public bool ValidarUsuario()
        {
            try
            {

                AdministradorITM admin = dbTorneoITM.AdministradorITMs.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (admin == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                login.Usuario = admin.Usuario;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                AdministradorITM admin = dbTorneoITM.AdministradorITMs.FirstOrDefault(u => u.Usuario == login.Usuario && u.Clave == login.Clave);
                if (admin == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                login.Clave = admin.Clave;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }

        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbTorneoITM.Set<AdministradorITM>()
                       where U.Usuario == login.Usuario &&
                               U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Usuario,
                           Autenticado = true,
                           Token = token,
                           Perfil = "Administrador",
                           Mensaje = "Autenticado con exito"
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}