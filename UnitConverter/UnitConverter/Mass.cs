//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitConverter
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mass
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public Nullable<double> BaseValue { get; set; }
    
        public virtual Category Category1 { get; set; }
    }
}
