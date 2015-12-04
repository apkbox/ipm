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
    
    public partial class Asset
    {
        public Asset()
        {
            this.AssetInstances = new HashSet<AssetInstance>();
        }
    
        public int AssetId { get; set; }
        public string TickerSymbol { get; set; }
        public string AssetName { get; set; }
        public decimal DividendYield { get; set; }
        public decimal MER { get; set; }
        public decimal LastMarketPrice { get; set; }
        public System.DateTime LastQuoteDate { get; set; }
    
        public virtual ICollection<AssetInstance> AssetInstances { get; set; }
    }
}