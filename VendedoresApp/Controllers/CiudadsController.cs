using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Model.Models;
using VendedoresApp.Functions;
using VendedoresApp.Models;

namespace VendedoresApp.Controllers
{
    public class CiudadsController : ApiController
    {
        private CiudadFunctions _ciudad = new CiudadFunctions();

        [HttpGet]
        [Route("api/Ciudad")]
        public IQueryable<CiudadDescripcion> GetCitys()
        {
            return _ciudad.GetAllCitys();
        }

        // GET: api/Ciudad/5
        [HttpGet]
        [Route("api/Ciudad/{descripcion}")]
        public IHttpActionResult GetVendedorByCodigo(string descripcion)
        {
            var ciudad = _ciudad.GetCiudadByCodigo(descripcion);
            if (ciudad == null)
            {
                return BadRequest("No existe el vendedor");
            }
            return Ok(ciudad);
        }

        // POST: api/Ciudad/create
        [HttpPost]
        [Route("api/Ciudad/create")]
        public HttpResponseMessage Create(Ciudad ciudad)
        {
            if (string.IsNullOrEmpty(ciudad.DESCRIPCION))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Verifique los datos, Nopueden ser vacios.");
            }
            else
            {
                try
                {
                    var ciudadFunction = new CiudadFunctions();
                    ciudadFunction.CreateCiudad(ciudad);

                    var mesg = Request.CreateResponse(HttpStatusCode.Created);
                    mesg.Headers.Location = new Uri(Request.RequestUri + ciudad.CODIGO.ToString());

                    return mesg;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}