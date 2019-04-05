using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApi.Models
{
    public class Point
    {
        public uint SRID;
        public byte byte_order;
        public int type_info;
        public double x;
        public double y;

     
        // Constructor that parses the internal MySQL Geometry Storage Format to retrieve the x, y attributes 
        // of a Geometric Point object. See https://dev.mysql.com/doc/refman/5.7/en/gis-data-formats.html
        public Point(byte[] s)
        {
            SRID = BitConverter.ToUInt32(s, 0);
            byte_order = s[4];
            type_info = BitConverter.ToInt32(s, 5);
            x = BitConverter.ToDouble(s, 9);
            y = BitConverter.ToDouble(s, 17);
        }
    }
}
