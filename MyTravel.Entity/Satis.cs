//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTravel.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satis
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int MehsulID { get; set; }
        public decimal Qiymet { get; set; }
        public short Eded { get; set; }
        public Nullable<short> Endirim { get; set; }
        public string ElaqeTel { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Messaj { get; set; }
        public string SatisOzellikleri { get; set; }
        public bool IsSaled { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Mehsul Mehsul { get; set; }
    }
}
