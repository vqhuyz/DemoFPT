using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        private static string connection = "User Id=system;Password=vothien1;DATA SOURCE=localhost:1521/ORCL;PERSIST SECURITY INFO=True;USER ID=SYSTEM";
        static void Main(string[] args)
        {
            //using (var con = new OracleConnection(connection))
            //{
            //    con.Open();
            //    OracleCommand cmd = con.CreateCommand();
            //    cmd.CommandText = "select name,address,phone,phongban_id from tbl_nhanvien where nhanvien_id = 2";
            //    OracleDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("Name: " + reader.GetString(0));
            //        Console.WriteLine("Address: " + reader.GetString(1));
            //        Console.WriteLine("Phone: " + reader.GetString(2));
            //        Console.WriteLine("PhongBan: " + reader.GetDecimal(3));
            //    }
            //    Console.WriteLine();
            //    Console.ReadLine();
            //}
            using (var con = new OracleConnection(connection))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_getbyid_nhanvien";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_nhanvien", OracleDbType.Int32).Value = 2;
                cmd.Parameters.Add("p_address", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Output;
                con.Open();
                var test = cmd.ExecuteNonQuery();
            }
        }
    }
}
