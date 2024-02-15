using System;
using DAL;
using Domain;

namespace BLL
{

    public class PhoneRepository
    {
        public UnitOfWork db;
        PhoneBookContext _contex;
        public PhoneRepository(PhoneBookContext _con)
        {
             _contex = _con;
            db = new UnitOfWork(_con);
        }

        public List<Person> GetUser()
        {
            var q = db.personrepository.GetByList();
            return q;
        }

        public int InsertPhone()
        {
            Person b = new Person();
            PersonRepository pr = new PersonRepository(_contex);
            b = pr.GetUser().FirstOrDefault();
            Phone p = new Phone();
            p.Person = b;
            p.PhoneNumber = "09137232814";
            p.Type = PhoneType.Work;
            p.PersonId = b.Id;
            db.phonerepository.Insert(p);
         
            if (db.save() > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }


    }
}

