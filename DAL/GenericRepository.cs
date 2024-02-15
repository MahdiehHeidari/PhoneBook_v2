using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.DataContext;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DAL
{

    public class GenericRepository<TEntity> where TEntity : class
    {
        internal PhoneBookContext context;
        internal DbSet<TEntity> dbset;
        public GenericRepository(PhoneBookContext context)
        {
            this.context = new PhoneBookContext(PhoneBookContext.ops.dbOptions);

            this.dbset = context.Set<TEntity>();
        }

        /// <summary>
        /// بازگردادندن اطلاعات با شناسه مشخص
        /// </summary>
        /// <param name="id">کلید اصلی</param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return dbset.Find(id);
        }

        /// <summary>
        /// بازگرداندن اطلاعات به صورت لیست
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> GetByList()
        {
            return dbset.ToList();
        }

        /// <summary>
        /// ذخیره اطلاعات با خروجی مشخص
        /// </summary>
        /// <param name="entity">مقدار ذخیره سازی</param>
        /// <param name="_save"></param>
        /// <returns></returns>
        public virtual TEntity Insert_RrturnTEntity(TEntity entity, bool _save = false)
        {
            dbset.Add(entity);
            if (_save)
            {
                context.SaveChanges();
            }

            return entity;
        }


        /// <summary>
        /// ذخیره اطلاعات ورودی
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }


        public virtual TEntity Delete_ReturnEntity(object id)
        {
            TEntity entity = GetById(id);
            dbset.Attach(entity);
            return dbset.Remove(entity).Entity;
        }

        public virtual TEntity Delete_ReturnEntity(TEntity entity)
        {
            dbset.Attach(entity);
            return dbset.Remove(entity).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            dbset.Attach(entity);
            dbset.Remove(entity);
        }

        public virtual TEntity Updete_Return(TEntity entity)
        {
            TEntity entity1 = dbset.Attach(entity).Entity;
            context.Entry(entity).State = EntityState.Modified;
            return entity1;
        }

        public virtual void Update(TEntity entity)
        {
            TEntity entity1 = dbset.Attach(entity).Entity;
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// حذف داده ها به صورت گروهی
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="save"></param>
        public virtual void Delete(List<TEntity> entities, bool save = false)
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
        public virtual void Update(List<TEntity> entities, bool save = false)
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
        public virtual void Update‌ById(TEntity entitie, bool save = true)
        {
          
            context.Update(entitie);
           
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
        public virtual void Insert(List<TEntity> entities, bool save = false)
        {
            dbset.AddRange(entities);
            if (save)
            {
                context.SaveChanges();
            }
        }
    }
}


