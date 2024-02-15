using System;
using Microsoft.EntityFrameworkCore;

namespace DAL
{

        public class GenericRepository<TEntity> where TEntity : class
        {
            internal PhoneBookContext context;
            internal DbSet<TEntity> dbset;
            public GenericRepository(PhoneBookContext context)
            {
                this.context = context;
          
                this.dbset = context.Set<TEntity>();
            }

            /// <summary>
            /// بازگرداندن اطلاعات با شناسه مشخص
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
            /// درج داده ها در جدول با خروجی همان داده ها
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="_save"></param>
            /// <returns></returns>
            public virtual TEntity Insert_ReturnEntity(TEntity entity, bool _save = false)
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
            public virtual void Insert(TEntity entity)
            {
                dbset.Add(entity);
            }

            /// <summary>
            /// حذف کردن با خروجی همان جدول
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual TEntity Delete_ReturnEntity(TEntity entity)
            {
                dbset.Attach(entity);
                return dbset.Remove(entity).Entity;
            }

            public virtual TEntity Delete_ReturnEntity(object id)
            {
                TEntity entity = GetById(id);
                dbset.Attach(entity);
                return dbset.Remove(entity).Entity;
            }

            public virtual void Delete(TEntity entity)
            {
                dbset.Attach(entity);
                dbset.Remove(entity);
            }

            /// <summary>
            /// ویرایش با خروجی داده ها
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual TEntity Update_ReturnEntity(TEntity entity)
            {
                TEntity entity1 = dbset.Attach(entity).Entity;
                context.Entry(entity).State = EntityState.Modified;
                return entity1;
            }

            /// <summary>
            /// ویرایش بدون خروجی
            /// </summary>
            /// <param name="entity"></param>
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



