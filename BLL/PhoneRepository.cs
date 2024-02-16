using System;
using DAL;
using DAL.DataContext;
using Domain;

namespace BLL
{

    public class PhoneRepository
    {
        private UnitOfWork db;
     
        public PhoneRepository()
        {
           
            db = new UnitOfWork();
        }

        public List<Phone> GetAll()
        {
            var q = db.phonerepository.GetByList();
            return q;
        }

        public int InsertPhone(Phone p)
        {
            
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

        public Phone getPhoneByid(int id)
        {

            return db.phonerepository.GetById(id); ;
        }

        public void EditPhone(Phone p)
        {

            db.phonerepository.UpdateById(p, true);
        }

        public void Delete(Phone p)
        {
            db.phonerepository.Delete(p);
        }
    }
}

