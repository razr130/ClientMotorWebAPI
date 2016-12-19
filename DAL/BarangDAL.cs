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
    public class BarangDAL
    {
        private string GetConnstr()
        {
            return ConfigurationManager.ConnectionStrings["StokDbConnectionString"].ConnectionString;
        }

        //Mengambil semua data dari table
        public IEnumerable<Barang> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strsql = @"select * from Barang
                                    order by Nama asc";
                var result = conn.Query<Barang>(strsql);
                return result;
            }
        }

        

        public void Create(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strSql = @"insert into Barang(KodeBarang,IdJenisMotor,KategoriId,Nama,Stok,HargaBeli,HargaJual,TanggalBeli) 
                                  values(@KodeBarang,@IdJenisMotor,@KategoriId,@Nama,@Stok,@HargaBeli,@HargaJual,@TanggalBeli)";
                var par = new
                {
                    KodeBarang = barang.KodeBarang,
                    IdJenisMotor = barang.IdJenisMotor,
                    KategoriId = barang.KategoriId,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli

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

        public void Update(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {

                string strSql = @"update Barang set IdJenisMotor=@IdJenisMotor, KategoriId=@KategoriId, Nama=@Nama, Stok=@Stok, HargaBeli=@HargaBeli, HargaJual=@HargaJual, TanggalBeli=@TanggalBeli 
                                  where KodeBarang=@KodeBarang";
                var par = new
                {
                    KodeBarang = barang.KodeBarang,
                    IdJenisMotor = barang.IdJenisMotor,
                    KategoriId = barang.KategoriId,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli
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
        public void Delete(string KodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strSql = @"delete from Barang 
                                  where KodeBarang=@KodeBarang";
                var par = new { KodeBarang = KodeBarang };
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
        public IEnumerable<Barang> SearchByName(string namabarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strsql = @"select * from Barang where Nama=@Nama";
                var par = new
                {
                    Nama =  namabarang  };
                
                return conn.Query<Barang>(strsql, par);
            }
        }

        public IEnumerable<BarangVM> searchnamakategori (string namakategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strsql = @"select KodeBarang, Nama, Stok, HargaBeli, HargaJual, TanggalBeli, NamaKategori from Barang, Kategori
                                where Barang.KategoriId = Kategori.KategoriId and NamaKategori like @namaKategori";
                var par = new
                {
                    NamaKategori = "%" + namakategori + "%"
                };

                return conn.Query<BarangVM>(strsql, par);
            }
        }

        public Barang GetById(string kodebarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnstr()))
            {
                string strSql = @"select * from Barang 
                              where KodeBarang=@KodeBarang";
                var par = new
                {
                    KodeBarang = kodebarang
                };
                return conn.Query<Barang>(strSql, par).SingleOrDefault();
            }

        }
    }
}
