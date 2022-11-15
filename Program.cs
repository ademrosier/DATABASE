using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            service.Start();
        }
    }
}
