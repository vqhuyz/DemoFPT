using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using OracleFPT.DI.Interface;
using OracleFPT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OracleFPT.DI.Implements
{
    public class DapperRepository : IDapperRepository
    {
        private static string connectionString = "User id=system;Password=vothien1;DATA SOURCE=localhost:1521/ORCL;PERSIST SECURITY INFO=True";

        public List<Employees> GetAll()
        {
            var sql = "PK_NHANVIEN.SP_GETALL";
            using (var db = new OracleConnection(connectionString))
            {
                var parameter = new OracleDynamicParameters();
                parameter.Add("p_employee", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var list = db.Query<Employees>(sql, param: parameter, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
        }
        public Employees GetById(int id)
        {
            var sql = "PK_NHANVIEN.SP_GETBYID";
            using (var db = new OracleConnection(connectionString))
            {
                var parameter = new OracleDynamicParameters();
                parameter.Add("p_nhanvien_id", id);
                parameter.Add("p_employee", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var list = db.QueryFirstOrDefault<Employees>(sql, param: parameter, commandType: CommandType.StoredProcedure);
                return list;
            }
        }
        public void Create(Employees emp)
        {
            var sql = "PK_NHANVIEN.SP_INSERT";
            using (var db = new OracleConnection(connectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("p_name", emp.NAME, DbType.String, ParameterDirection.Input);
                parameter.Add("p_address", emp.ADDRESS, DbType.String, ParameterDirection.Input);
                parameter.Add("p_phone", emp.PHONE, DbType.String, ParameterDirection.Input);
                parameter.Add("p_phongban_id", emp.PHONGBAN_ID, DbType.Int32, ParameterDirection.Input);
                db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Employees emp)
        {
            var sql = "PK_NHANVIEN.SP_UPDATE";
            using (var db = new OracleConnection(connectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("p_nhanvien_id", emp.NHANVIEN_ID, DbType.Int32, ParameterDirection.Input);
                parameter.Add("p_name", emp.NAME, DbType.String, ParameterDirection.Input);
                parameter.Add("p_address", emp.ADDRESS, DbType.String, ParameterDirection.Input);
                parameter.Add("p_phone", emp.PHONE, DbType.String, ParameterDirection.Input);
                parameter.Add("p_phongban_id", emp.PHONGBAN_ID, DbType.Int32, ParameterDirection.Input);
                db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            var sql = "PK_NHANVIEN.sp_DELETE";
            using (var db = new OracleConnection(connectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("p_nhanvien_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                db.QueryFirstOrDefault<Employees>(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}