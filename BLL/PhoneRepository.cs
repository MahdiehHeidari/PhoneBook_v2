﻿using System;
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

        public List<Person> GetUser()
        {
            var q = db.personrepository.GetByList();
            return q;
        }

        public int InsertPhone()
        {
            Person b = new Person();
            PersonRepository pr = new PersonRepository();
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

