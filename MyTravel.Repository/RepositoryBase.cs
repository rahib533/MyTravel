using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTravel.Repository
{
    using Entity;
    public class RepositoryBase<TT> : IRepository<TT> where TT : class
    {
        public TT Add(TT entity)
        {
            try
            {
                TT data = Tools.Context.Set<TT>().Add(entity);
                Tools.Context.SaveChanges();
                return data;
            }
            catch (Exception )
            {

                return null;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                TT data = Tools.Context.Set<TT>().Find(id);
                Tools.Context.Set<TT>().Remove(data);
                Tools.Context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public List<TT> Select()
        {
            return Tools.Context.Set<TT>().ToList();
        }

        public TT SelectById(int id)
        {
            TT data = Tools.Context.Set<TT>().Find(id);
            return data;
        }

        public TT Update(TT entity)
        {
            try
            {
                Tools.Context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
