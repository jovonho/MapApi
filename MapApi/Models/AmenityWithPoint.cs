using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApi.Models
{
    public class AmenityWithPoint
    {
        public long Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Point Pt { get; set; }

        public AmenityWithPoint(Amenity a)
        {
            Id = a.Id;
            Lat = a.Lat;
            Lon = a.Lon;
            Type = a.Type;
            Name = a.Name;
            Pt = new Point(a.Pt);
        }


    }
}
