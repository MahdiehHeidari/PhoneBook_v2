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
           
            return db.personrepository.GetByList();
        }

        public Person getuserid(int id)
        {
           
            return db.personrepository.GetById(id); ;
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

        public void EditUser(Person p)
        {
        
          db.personrepository.UpdateById(p,true);
        }
        
         public void DeleteById(Person p )
        {
            db.personrepository.Delete(p);
        }
    }
}

