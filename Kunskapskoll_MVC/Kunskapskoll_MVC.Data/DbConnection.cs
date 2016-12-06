using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kunskapskoll_MVC.Data.Tables;
using System.Data.Entity.Migrations;

namespace Kunskapskoll_MVC.Data
{
    public class DbConnection : IAdressBook
    {
        public void addOrEdit(PersonAdress personAdress)
        {
            using (var ctx = new AdressBokContext())
            {
                var Entity = ctx.PersonAdress.FirstOrDefault(x => x.Id == personAdress.Id)
                ?? new PersonAdress() { Id = Guid.NewGuid()};
                Entity.Namn = personAdress.Namn;
                Entity.Adress = personAdress.Adress;
                Entity.Telefonnummer = personAdress.Telefonnummer;
                Entity.Updaterades = DateTime.Now;

                ctx.PersonAdress.AddOrUpdate(Entity);
                ctx.SaveChanges();
            }
        }

        public List<PersonAdress> All()
        {
            using (var ctx = new AdressBokContext())
            {
                var all = ctx.PersonAdress.ToList()
                    ?? new List<PersonAdress>();
                return all;
            }
        }

        public void Delete(Guid Id)
        {
            using (var ctx = new AdressBokContext())
            {
                var EntityToDelete = ctx.PersonAdress.FirstOrDefault(x => x.Id == Id);
                ctx.PersonAdress.Remove(EntityToDelete);
                ctx.SaveChanges();
            }

        }

        public PersonAdress One(Guid id)
        {
            using (var ctx = new AdressBokContext())
            {
                return ctx.PersonAdress.SingleOrDefault(x=> x.Id == id);
            }
        }
    }
}
