//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Бипит_лаба_10
{
    using System;
    using System.Collections.Generic;
    
    public partial class Arenda_book
    {
        public int Id { get; set; }
        public Nullable<int> id_fio { get; set; }
        public Nullable<int> id_book { get; set; }
        public Nullable<System.DateTime> Data_1 { get; set; }
        public Nullable<System.DateTime> Data_2 { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual FIO FIO { get; set; }
    }
}
