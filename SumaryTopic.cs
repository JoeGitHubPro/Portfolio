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
    
    public partial class SumaryTopic
    {
        public int ID { get; set; }
        public string SumaryTopicName { get; set; }
    
        public virtual SumaryCategory SumaryCategory { get; set; }
    }
}
