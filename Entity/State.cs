//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class State
    {
        public State()
        {
            this.Users = new HashSet<User>();
        }
    
        public int stateId { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
