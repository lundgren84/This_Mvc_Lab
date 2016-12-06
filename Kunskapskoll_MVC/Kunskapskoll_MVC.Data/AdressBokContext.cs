using Kunskapskoll_MVC.Data.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunskapskoll_MVC.Data
{
   public class AdressBokContext:DbContext
    {
       public DbSet<PersonAdress> PersonAdress { get; set; }
    }
}
