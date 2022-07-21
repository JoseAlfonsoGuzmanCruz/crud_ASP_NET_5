using crud_ASP_NET_5.Datos;
using crud_ASP_NET_5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_ASP_NET_5.Controllers
{
    public class CursosController : Controller
    {
        //instancia del contexto
        private readonly ApplicationDbContext contexto;
        //constructor que obtiene el contexto
        public CursosController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }
        //metodo que obtiene el objeto Curso, pasamos a lista y lo retornamos a la vista
        public IActionResult Index()
        {
            IEnumerable<Curso> listaCurso = contexto.curso;
            return View(listaCurso);
        }
    }
}
