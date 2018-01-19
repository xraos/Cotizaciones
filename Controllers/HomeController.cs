using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cotizaciones.Models;
using Cotizaciones.Data;
using Microsoft.AspNetCore.Http;

namespace Cotizaciones.Controllers
{
    public class HomeController : Controller
    {
        private CotizacionesContext _context;
        public HomeController(CotizacionesContext context)
        {
            _context = context;
        }

        ///Metodo que llama a la vista "Index" donde se tomara el nombre de usuario
        ///de la session, ademas de generar una lista con todos los usuarios registrados
        ///para poder mostrarlo a traves de una lista de usuarios llamada "Usuarios Registrados"
        public IActionResult Index()
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            return View(_context.Usuarios.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        ///metodo que llama a la vista Register
        public ActionResult Register()
        {
            return View();
        }

        ///metodo que ocurre inmediatamente cuando el usuario le da al boton registrar
        ///cuando el usuario esta en la vista de registrar usuario
        [HttpPost]
        public ActionResult Register(Usuario user)
        {
            ///si el estado del modelo es valido se procede a ingresar al usuario a la db
            if(ModelState.IsValid){
                ///crea el usuario como objeto
                _context.Usuarios.Add(user);
                ///guarda el usuario en la base de datos
                _context.SaveChanges();

                ModelState.Clear();
                ///envia un mensaje avisando que el usaurio se registro correctamente
                ViewBag.Message = user.NombreUsuario + "Ha sido registrado exitosamente!";
            }
            return View();
        }
        ///metodo que llama a la vista Login
        public ActionResult Login()
        {
            return View();
        }

        ///metodo que ocurre inmediatamente cuando el usuario le da al boton Ingresar
        ///cuando el usuario esta en la vista de iniciar sesion
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            ///verifica que el nombre de usuario y password que se ingreso este en la base de datos
            var cuenta = _context.Usuarios.Where(u => u.NombreUsuario == user.NombreUsuario && u.Password == user.Password).FirstOrDefault();
            ///si la cuenta existe y coinciden los datos se agregan estos datos como un contexto http llamado sesion
            ///que guardara la sesion iniciada durante toda la aplicacion
            if(cuenta != null)
            {
                HttpContext.Session.SetString("UsuarioID", cuenta.UsuarioID.ToString());
                HttpContext.Session.SetString("NombreUsuario", cuenta.NombreUsuario);
                ///redirecciona a la vista index
                return RedirectToAction("Index");
            }else
            {
                ///si los datos no existe o no coinciden se manda un mensaje de error
                ModelState.AddModelError("","Usuario o Password Estan Erroneos");
            }
            return View();
        }
        ///Este metodo no se utilizo ya que el mensaje de bienvenida se implemente en la vista Index
        public ActionResult Welcome()
        {
            if(HttpContext.Session.GetString("UsuarioID") != null)
            {
                ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
                return View();
                ///HttpContext.Session.GetString("UsuarioID");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }

        ///metodo que hace que la sesion ya iniciada se cierre
        public ActionResult Logout()
        {
            ///esta linea de codigo hace limpiar(clear) la session, borrandola
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
            
        }



    }
}
