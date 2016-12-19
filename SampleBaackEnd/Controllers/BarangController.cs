using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BO;
using DAL;

namespace SampleBaackEnd.Controllers
{
    public class BarangController : ApiController
    {
        // GET: api/Barang
        public IEnumerable<Barang> Get()
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.GetAll();
        }

        // GET: api/Kategori/5
        public IEnumerable<Barang> Get(string namabarang, bool sesi)
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.SearchByName(namabarang);
        }

        public IEnumerable<BarangVM> Get(string namakategori)
        {
            BarangDAL barangdal = new BarangDAL();
            return barangdal.searchnamakategori(namakategori);
        }

        // POST: api/Kategori
        public IHttpActionResult Post(Barang barang)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Create(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public IHttpActionResult Put(Barang barang)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Update(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Kategori/5
        public IHttpActionResult Delete(string id)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public Barang Get(string namabarang)
        //{
        //    BarangDAL barangdal = new BarangDAL();
        //    return barangdal.SearchByName(namabarang);
        //}
    }
}
