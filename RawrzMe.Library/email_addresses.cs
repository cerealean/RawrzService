//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RawrzMe.Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class email_addresses
    {
        public int id { get; set; }
        public string email_address { get; set; }
        public bool is_primary { get; set; }
        public bool is_verified { get; set; }
        public int user_id { get; set; }
    
        public virtual user user { get; set; }
    }
}
