//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portfolio
{
    using System;
    using System.Collections.Generic;
    
    public partial class Header
    {
        public int ID { get; set; }
        public string Header1 { get; set; }
    
        public virtual HeaderCategory HeaderCategory { get; set; }
    }
}
