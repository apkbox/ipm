//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ipm.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssetInstance
    {
        public AssetInstance()
        {
            this.AssetTransactions = new HashSet<AssetTransaction>();
        }
    
        public int AssetInstanceId { get; set; }
        public decimal BookCost { get; set; }
        public decimal MarketPrice { get; set; }
    
        public virtual Asset Asset { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<AssetTransaction> AssetTransactions { get; set; }
    }
}
