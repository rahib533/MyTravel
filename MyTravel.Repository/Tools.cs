using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTravel.Repository
{
    using Entity;
    public static class Tools
    {
        private static TravelDBEntities context;

        public static TravelDBEntities Context
        {
            get {
                if (context==null)
                {
                    context = new TravelDBEntities();
                }
                return context;
            }
            
        }
    }
}
