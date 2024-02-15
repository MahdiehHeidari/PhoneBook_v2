using System;
using DAL;
using Domain;

namespace BLL
{
	public class PersonRepository
	{
            public UnitOfWork db;
            public PersonRepository(PhoneBookContext _con)
            {
                db = new UnitOfWork(_con);
            }

        public List<Person> GetUser()
        {
            var q = db.personrepository.GetByList();
            return q;
        }

        public int InsertPerson()
        {
            Person b = new Person();
          
            b.FirstName = "mahdieh";
            b.LastName = "heidari";
            db.personrepository.Insert(b);
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

