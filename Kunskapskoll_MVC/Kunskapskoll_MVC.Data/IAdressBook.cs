using Kunskapskoll_MVC.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunskapskoll_MVC.Data
{
   public interface IAdressBook
    {
        void addOrEdit(PersonAdress personAdress);
        void Delete(Guid Id);
        List<PersonAdress> All();
        PersonAdress One(Guid id);
    }
}
