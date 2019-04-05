using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApi.Models
{
    public class Point
    {
        public double x { get; }
        public double y { get; }

        // Constructor that parses the internal MySQL Geometry Storage Format to retrieve the x, y attributes 
        // of a Geometric Point object. See https://dev.mysql.com/doc/refman/5.7/en/gis-data-formats.html
        public Point(byte[] s)
        {
            x = BitConverter.ToDouble(s, 9);
            y = BitConverter.ToDouble(s, 17);
        }
    }
}
