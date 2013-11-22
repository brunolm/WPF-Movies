using Movies.Domain;
using Movies.Infrastructure;
using System;
using System.Linq;

namespace Movies.Services
{
    public class ServiceBase<T> where T: IEntity
    {
        public static IQueryable<T> Get()
        {
            return EntityFactory.Current.Set<T>().AsQueryable();
        }

        public static T Get(int id)
        {
            return EntityFactory.Current.Set<T>().FirstOrDefault(o => o.ID == id);
        }

        public static void Add(T o)
        {
            EntityFactory.Current.Set<T>().Add(o);
            EntityFactory.Current.SaveChanges();
        }

        public static void Update()
        {
            EntityFactory.Current.SaveChanges();
        }

        public static void AddOrUpdate(T o) 
        {
            if (o.ID > 0)
            {
                Update();
            }
            else
            {
                Add(o);
            }
        }

        public static void Remove(T o)
        {
            EntityFactory.Current.Set<T>().Remove(o);
            EntityFactory.Current.SaveChanges();
        }
    }
}
