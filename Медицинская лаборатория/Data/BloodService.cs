//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Медицинская_лаборатория.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BloodService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Result { get; set; }
        public System.DateTime Finished { get; set; }
        public bool Accepted { get; set; }
        public int StatusId { get; set; }
        public int AnalyzerId { get; set; }
        public int UserId { get; set; }
    
        public virtual Analyzer Analyzer { get; set; }
        public virtual Blood Blood { get; set; }
        public virtual Service Service { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
    }
}
