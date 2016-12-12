using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class JenisMotorDAL
    {
        private string GetConnstr()
        {
            return ConfigurationManager.ConnectionStrings["StokDbConnectionString"].ConnectionString;
        }

        //Mengambil semua data dari table
        public IEnumerable<JenisMotor> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strsql = @"select * from JenisMotor 
                                    order by NamaJenisMotor asc";
                var result = conn.Query<JenisMotor>(strsql);
                return result;
            }
        }

        public JenisMotor GetById(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strSql = @"select * from JenisMotor 
                              where IdJenisMotor=@IdJenisMotor";
                var par = new
                {
                    IdJenisMotor = IdJenisMotor
                };
                return conn.Query<JenisMotor>(strSql, par).SingleOrDefault();
            }

        }

        public void Create(JenisMotor jenismotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strSql = @"insert into JenisMotor(NamaMerk,NamaJenisMotor) 
                                  values(@NamaMerk,@NamaJenisMotor)";
                var par = new { NamaMerk = jenismotor.NamaMerk,
                                NamaJenisMotor = jenismotor.NamaJenisMotor};
                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public void Update(JenisMotor jenismotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {

                string strSql = @"update JenisMotor set NamaMerk=@NamaMerk, NamaJenisMotor=@NamaJenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";
                var par = new
                {
                    NamaMerk = jenismotor.NamaMerk,
                    NamaJenisMotor = jenismotor.NamaJenisMotor,
                    IdJenisMotor = jenismotor.IdJenisMotor
                };

                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }
        public void Delete(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strSql = @"delete from JenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";
                var par = new { IdJenisMotor = IdJenisMotor };
                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }
    }
}
