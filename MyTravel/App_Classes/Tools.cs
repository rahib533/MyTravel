using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTravel.App_Classes
{
    using Entity;
    using System.Configuration;
    using System.Drawing;

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

        private static Size meh;

        public static Size MehsulBoyuk
        {
            get {
                meh.Height = Convert.ToInt32(ConfigurationManager.AppSettings["boyukH"]);
                meh.Width = Convert.ToInt32(ConfigurationManager.AppSettings["boyukW"]);
                return meh;
            }
        }

        private static Size mehh;

        public static Size MehsulOrta
        {
            get
            {
                mehh.Height = Convert.ToInt32(ConfigurationManager.AppSettings["ortaH"]);
                mehh.Width = Convert.ToInt32(ConfigurationManager.AppSettings["ortaW"]);
                return mehh;
            }
        }

        private static Size meeh;

        public static Size MehsulKicik
        {
            get
            {
                meeh.Height = Convert.ToInt32(ConfigurationManager.AppSettings["kicikH"]);
                meeh.Width = Convert.ToInt32(ConfigurationManager.AppSettings["kicikW"]);
                return meeh;
            }
        }

        private static Size slide;

        public static Size Slider
        {
            get
            {
                slide.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sliderH"]);
                slide.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sliderW"]);
                return slide;
            }
        }
    }
}