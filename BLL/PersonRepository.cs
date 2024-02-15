using System;
using DAL;
using DAL.DataContext;
using Domain;

namespace BLL
{
	public class PersonRepository
	{

        private UnitOfWork db;
        PhoneBookContext _contex;
        public PersonRepository()
        {
            
            db = new UnitOfWork();
        }

        public List<Person> GetUser()
        {
            var q = db.personrepository.GetByList();
            return q;
        }

        public Person getuserid(int id)
        {
            var q = db.personrepository.GetById(id);
            return q;
        }

        public int InsertPerson(Person p)
        {
            
            db.personrepository.Insert(p);
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

