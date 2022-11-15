using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Hotel
{
    public class Service
    {
        string con2= "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hotel;Integrated Security=True;"
                   + "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
 
        private List<Facility> GetAllFacility(SqlConnection connection)
        {
            string queryAllFacility = "SELECT * FROM DemoFacility";
            List<Facility> facilityList = new List<Facility>();
            SqlCommand command = new SqlCommand(queryAllFacility, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Facility facility = new Facility();
                facility.Facility_id = reader.GetInt32(0);
                facility.Facility_name = reader.GetString(1);
                facilityList.Add(facility);
            }
            reader.Close();
            return facilityList;
        }
        private void CreateFacility(SqlConnection connection, Facility facility)
        {
            string createCommand = $"INSERT INTO DemoFacility (Name) VALUES('{facility.Facility_name}')" ;
            SqlCommand command = new SqlCommand(createCommand, connection);
            command.ExecuteNonQuery();
        }  
        private void DeleteFacility(SqlConnection connection, int Facility_id)
        {
            string deleteCommand = $"DELETE FROM DemoFacility WHERE facility_id = {Facility_id}";
            SqlCommand command = new SqlCommand(deleteCommand, connection);
            command.ExecuteNonQuery();
        }
        private void UpdateFacility(SqlConnection connection, string name, int id)
        {
            string updateCommand = $"UPDATE DemoFacility SET Name = '{name}' WHERE facility_id = {id}";
            SqlCommand command = new SqlCommand(updateCommand, connection);
            command.ExecuteNonQuery();
        }
        private HotelFacility GetHotelFacility(SqlConnection connection, int id)
        {
            string queryStringHotelFacility = $"SELECT FROM HotelFacility WHERE id ={id}";
            Console.WriteLine(queryStringHotelFacility);
            SqlCommand query = new SqlCommand(queryStringHotelFacility, connection);
            SqlDataReader reader = query.ExecuteReader();

            Console.WriteLine($"{id}");

            if (!reader.HasRows)
            {
                Console.WriteLine("No HotelFacility in database");
                reader.Close();
                return null;
            }
            HotelFacility hotelFacility = null;

            if (reader.Read())
            {
                hotelFacility = new HotelFacility()
                {
                    ID = reader.GetInt32(0),
                    Facility_id = reader.GetInt32(1),
                    Hotel_No = reader.GetInt32(2)
                };
                Console.WriteLine(hotelFacility);
            }
            reader.Close();
            Console.WriteLine();
            return hotelFacility;
        }
        private void CreatHotelFacility(SqlConnection connection, HotelFacility hotelfacility)
        {
            string createCommand = $"INSERT INTO HotelFacility(Hotel_No, Facility_id) VALUES({hotelfacility.Hotel_No},{hotelfacility.Facility_id})";
            SqlCommand command = new SqlCommand(createCommand, connection);
            command.ExecuteNonQuery();
        }
        private void DeleteHotelFacility(SqlConnection connection, int id)
        {
            string deleteCommand = $"DELETE FROM HotelFacility where ID = {id}";
            SqlCommand command = new SqlCommand(deleteCommand, connection);
            command.ExecuteNonQuery();
        }
        private void UpdateHotelFacility(SqlConnection connection, HotelFacility hotelfacility)
        {
            string updateCommand = $"UPDATE HotelFacility SET Hotel_No ={hotelfacility.Hotel_No},Facility_id ={hotelfacility.Facility_id} WHERE id ={hotelfacility.ID}";
            SqlCommand command = new SqlCommand(updateCommand, connection);
            command.ExecuteNonQuery();
        }
        public void Start()
        {
            using (SqlConnection connection = new SqlConnection(con2))
            {
                connection.Open();
                List<Facility> facilityList = (GetAllFacility(connection));
                foreach (var facility in facilityList)
                {
                   Console.WriteLine("facility id is {0} and name is {1}", facility.Facility_id, facility.Facility_name);
                }
                //Facility NewFacility = new Facility()
                //{
                //    Facility_name = "Netflix"
                //};
                //Facility NewFacility2 = new Facility()
                //{
                //    Facility_name = "Mini Golf"
                //};
                //CreateFacility(connection, NewFacility);
                //CreateFacility(connection, NewFacility2);
                DeleteFacility(connection, 1006);
            }
        }

    }
}
