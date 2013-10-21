using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class ServiceBase<T> where T: class
    {
        public static IQueryable<T> Get()
        {
            return EntityFactory.Current.Set<T>().AsQueryable();
        }

        public static T Get(int id)
        {
            return EntityFactory.Current.Set<T>().FirstOrDefault(o => (int)(o as EntityObject).EntityKey.EntityKeyValues[0].Value == id);
        }

        public static void Add(T o)
        {
            //EntityFactory.Current.Set<T>().Add(o);
            //EntityFactory.Current.SaveChanges();
        }

        public static void Update()
        {
            EntityFactory.Current.SaveChanges();
        }

        public static void AddOrUpdate(T o)
        {
            if ((int)(o as EntityObject).EntityKey.EntityKeyValues[0].Value > 0)
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
