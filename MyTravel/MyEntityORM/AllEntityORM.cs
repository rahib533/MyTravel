using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTravel.MyEntityORM
{
    public static class AllEntityORM
    {
        private static KategoriyaORM kat;

        public static KategoriyaORM KategoriORM
        {
            get {
                if (kat==null)
                {
                    kat = new KategoriyaORM();
                }
                return kat;
            }
        }
        //---------------------------------------------------
        private static MehsulORM meh;

        public static MehsulORM MehsulORM
        {
            get
            {
                if (meh == null)
                {
                    meh = new MehsulORM();
                }
                return meh;
            }
        }
        //-----------------------------------------------------
        private static PhotoORM pho;

        public static PhotoORM PhotoORM
        {
            get
            {
                if (pho == null)
                {
                    pho = new PhotoORM();
                }
                return pho;
            }
        }
        //-----------------------------------------------------
        private static OzellikTipORM ozt;

        public static OzellikTipORM OzellikTipORM
        {
            get
            {
                if (ozt == null)
                {
                    ozt = new OzellikTipORM();
                }
                return ozt;
            }
        }
        //-----------------------------------------------------
        private static OzellikDeyerORM ozd;

        public static OzellikDeyerORM OzellikDeyerORM
        {
            get
            {
                if (ozd == null)
                {
                    ozd = new OzellikDeyerORM();
                }
                return ozd;
            }
        }
        //-----------------------------------------------------
        private static MehsulOzellikORM mo;

        public static MehsulOzellikORM MehsulOzellikORM
        {
            get
            {
                if (mo == null)
                {
                    mo = new MehsulOzellikORM();
                }
                return mo;
            }
        }
        //-----------------------------------------------------
        private static MessajORM msg;

        public static MessajORM MessajORM
        {
            get
            {
                if (msg == null)
                {
                    msg = new MessajORM();
                }
                return msg;
            }
        }
        //-----------------------------------------------------
        private static SatisORM sts;

        public static SatisORM SatisORM
        {
            get
            {
                if (sts == null)
                {
                    sts = new SatisORM();
                }
                return sts;
            }
        }
        //-----------------------------------------------------
    }
}