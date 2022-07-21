using crud_ASP_NET_5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_ASP_NET_5.Datos
{
    //Se tiene que usar los parametros de la clase DbContext (herencia).
    public class ApplicationDbContext:DbContext
    {
        //generamos el constructor de la clase context para el uso de la logica necesaria 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {

        }
        //Uso de la tabla Curso
        public DbSet<Curso> curso { set; get; }
    }
}
