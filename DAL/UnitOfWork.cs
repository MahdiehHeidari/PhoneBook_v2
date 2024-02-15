using System;
using Domain;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        PhoneBookContext context = null;
        public UnitOfWork()
        {
            context = new PhoneBookContext();
        }


        private GenericRepository<Person> PersonRepository;
        public GenericRepository<Person> personrepository
        {
            get
            {
                if (this.PersonRepository == null)
                    this.PersonRepository = new GenericRepository<Person>(context);
                return PersonRepository;
            }
        }

        private GenericRepository<Phone> PhoneRepository;
        public GenericRepository<Phone> phonerepository
        {
            get
            {
                if (this.PhoneRepository == null)
                    this.PhoneRepository = new GenericRepository<Phone>(context);
                return PhoneRepository;
            }
        }

        public int save()
        {
            return context.SaveChanges();
        }

        private bool Disposed = false;
        protected virtual void dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.Disposed = true;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

