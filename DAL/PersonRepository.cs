using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class PersonRepository
	{
        internal PhoneBookContext context;
        internal DbSet<Person> dbset;
        public PersonRepository(PhoneBookContext context)
        {
            this.context = context;

            this.dbset = context.Persons;
        }

        /// <summary>
        /// بازگرداندن اطلاعات با شناسه مشخص
        /// </summary>
        /// <param name="id">کلید اصلی</param>
        /// <returns></returns>
        public virtual Person GetById(object id)
        {
            return dbset.Find(id);
        }

        /// <summary>
        /// بازگرداندن اطلاعات به صورت لیست
        /// </summary>
        /// <returns></returns>
        public virtual List<Person> GetByList()
        {
            return dbset.ToList();
        }

        /// <summary>
        /// درج داده ها در جدول با خروجی همان داده ها
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="_save"></param>
        /// <returns></returns>
        public virtual Person Insert_ReturnEntity(Person entity, bool _save = false)
        {
            dbset.Add(entity);
            if (_save)
            {
                context.SaveChanges();
            }

            return entity;
        }

        /// <summary>
        /// درج اطلاعات بدون خروجی
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(Person entity)
        {
            dbset.Add(entity);
        }

        /// <summary>
        /// حذف کردن با خروجی همان جدول
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Person Delete_ReturnEntity(Person entity)
        {
            dbset.Attach(entity);
            return dbset.Remove(entity).Entity;
        }

        public virtual Person Delete_ReturnEntity(object id)
        {
            Person entity = GetById(id);
            dbset.Attach(entity);
            return dbset.Remove(entity).Entity;
        }

        public virtual void Delete(Person entity)
        {
            dbset.Attach(entity);
            dbset.Remove(entity);
        }

        /// <summary>
        /// ویرایش با خروجی داده ها
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Person Update_ReturnEntity(Person entity)
        {
            Person entity1 = dbset.Attach(entity).Entity;
            context.Entry(entity).State = EntityState.Modified;
            return entity1;
        }

        /// <summary>
        /// ویرایش بدون خروجی
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(Person entity)
        {
            Person entity1 = dbset.Attach(entity).Entity;
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// حذف داده ها به صورت گروهی
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="save"></param>
        public virtual void Delete(List<Person> entities, bool save = false)
        {
            dbset.RemoveRange(entities);
            if (save)
            {
                context.SaveChanges();
            }
        }

        /// <summary>
        /// ویرایش گروهی
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="save"></param>
        public virtual void Update(List<Person> entities, bool save = false)
        {
            foreach (var item in entities)
            {
                dbset.Attach(item);
            }

            if (save)
            {
                context.SaveChanges();
            }
        }

        /// <summary>
        /// وارد سازی گروهی داده ها
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="save"></param>
        public virtual void Insert(List<Person> entities, bool save = false)
        {
            dbset.AddRange(entities);
            if (save)
            {
                context.SaveChanges();
            }
        }
    }
}

