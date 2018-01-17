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
        public IActionResult Index()
        {
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
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Usuario user)
        {
            if(ModelState.IsValid){
                _context.Usuarios.Add(user);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = user.NombreUsuario + "Ha sido registrado exitosamente!";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            var cuenta = _context.Usuarios.Where(u => u.NombreUsuario == user.NombreUsuario && u.Password == user.Password).FirstOrDefault();
            if(cuenta != null)
            {
                HttpContext.Session.SetString("UsuarioID", cuenta.UsuarioID.ToString());
                HttpContext.Session.SetString("Nombre de Usuario", cuenta.NombreUsuario);
                return RedirectToAction("Welcome");
            }else
            {
                ModelState.AddModelError("","Usuario o Password Estan Erroneos");
            }
            return View();
        }
        
        public ActionResult Welcome()
        {
            if(HttpContext.Session.GetString("UsuarioID") != null)
            {
                ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
            
        }



    }
}
