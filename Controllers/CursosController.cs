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
        //los siguientes metodos Crear entan en sobrecarga de metodos
        //el segundo recibe el Curso por el method = post de la vista asociada y lo agrega a la base de datos  
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Curso c)
        {
            //si es valida la informacion dependiendo de las DataAnnotations
            if (ModelState.IsValid)
            {
                contexto.curso.Add(c);
                contexto.SaveChanges();
                return RedirectToAction("Index");//redireccion a la vista principal
            }
            return View();
        }
        //los siguientes dos metodos en "sobre carga" por que (es la misma vista al que hace la peticion y recepcion)
        //recibe un id que identifica en que registro se esta Editando
        public IActionResult Editar(int? id)
        {
            //lo busca
            Curso c = contexto.curso.Find(id);
            //vistas que redirecciona al usuario identificando si el registro es nulo o no
            if (c == null)
            {
                return NotFound();
            }
            return View(c);
        }
        //responde al phost 
        [HttpPost]
        public IActionResult Editar(Curso c)
        {
            //verifica si el registro es valido
            if (ModelState.IsValid)
            {
                //hace la actualizacion
                contexto.curso.Update(c);
                //guarda los cambios
                contexto.SaveChanges();
                //redirecciona al usuario
                return RedirectToAction("Index");
            }
            //si el registro no es valido lo deja en la misma vista
            return View();
        }
        //recibe el id del registro que tiene que borrar
        public IActionResult Borrar(int? id)
        {
            //lo busca
            Curso c = contexto.curso.Find(id);
            //si es nulo retorna not font
            if (c == null)
            {
                return NotFound();
            }
            //lo borra
            contexto.curso.Remove(c);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
