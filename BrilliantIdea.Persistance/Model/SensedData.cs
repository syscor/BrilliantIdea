//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrilliantIdea.Persistance.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SensedData
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedHour { get; set; }
        public string ValueSeries { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public int RangeId { get; set; }
        public string Message { get; set; }
    
        public virtual Sensors Sensors { get; set; }
    }
}
