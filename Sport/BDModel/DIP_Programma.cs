//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sport.BDModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIP_Programma
    {
        public int id_Programma { get; set; }
        public int id_kyrs { get; set; }
        public int id_DN { get; set; }
        public string nazvanie { get; set; }
        public int id_Pol { get; set; }
    
        public virtual DIP_DN DIP_DN { get; set; }
        public virtual DIP_Kyrs DIP_Kyrs { get; set; }
        public virtual DIP_Polzovatel DIP_Polzovatel { get; set; }
    }
}