using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Hotel
{
    public class HotelFacility
    {
        public int ID { get; set; }
        public int Hotel_No { get; set; }
        public int Facility_id { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Hotel_No}, {Facility_id}";
        }
    }
    
 
}
