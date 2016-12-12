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
    public class JenisMotorController : ApiController
    {
        //Memanggil semua data dari DAL
        // GET: api/JenisMotor
        public IEnumerable<JenisMotor> Get()
        {
            JenisMotorDAL jenismotorDAL = new JenisMotorDAL();
            return jenismotorDAL.GetAll();
        }

        // GET: api/Kategori/5
        public JenisMotor Get(int id)
        {
            JenisMotorDAL jenismotorDAL = new JenisMotorDAL();
            return jenismotorDAL.GetById(id);
        }

        // POST: api/Kategori
        public IHttpActionResult Post(JenisMotor jenismotor)
        {
            JenisMotorDAL jenismotorDAL = new JenisMotorDAL();
            try
            {
                jenismotorDAL.Create(jenismotor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public IHttpActionResult Put(JenisMotor jenismotor)
        {
            JenisMotorDAL jenismotorDAL = new JenisMotorDAL();
            try
            {
                jenismotorDAL.Update(jenismotor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Kategori/5
        public IHttpActionResult Delete(int id)
        {
            JenisMotorDAL jenismotorDAL = new JenisMotorDAL();
            try
            {
                jenismotorDAL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
