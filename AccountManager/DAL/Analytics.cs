//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountManager.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Analytics
    {
        public int IdAnalytics { get; set; }
        public int IdAccount { get; set; }
        public int SameLogin { get; set; }
        public int SamePassword { get; set; }
        public int NumberChange { get; set; }
    
        public virtual Accounts Accounts { get; set; }
    }
}
