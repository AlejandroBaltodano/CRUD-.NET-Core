using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CORE.UI.Models.Context
{
    public class Context:DbContext
    {

        public Context(DbContextOptions<Context> options):base (options)
        {


        }

        public DbSet<Modelos.Persona> Personas { get; set; }
    }
}
