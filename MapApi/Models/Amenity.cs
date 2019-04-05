using System;
using System.Collections.Generic;

namespace MapApi.Models
{
    public partial class Amenity
    {
        public long Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public byte[] Pt { get; set; }

    }


}
