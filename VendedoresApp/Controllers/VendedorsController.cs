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
    public class VendedorsController : ApiController
    {
        private VendedorFunctions _vendedor = new VendedorFunctions();

        // GET: api/Vendedors
        [HttpGet]
        [Route("api/Vendedors")]
        public IQueryable<CiudadVendedor> GetVendedors()
        {
            return _vendedor.GetALLVendedors();
        }

        // GET: api/Vendedors/5
        [HttpGet]
        [Route("api/vendedors/{codigo}")]
        public IHttpActionResult GetVendedorByCodigo(byte codigo)
        {
            var vendedor = _vendedor.GetVendedorByCodigo(codigo);
            if (vendedor == null)
            {
                return BadRequest("No existe el vendedor");
            }
            return Ok(vendedor);
        }

        // POST: api/Vendedors/create
        [HttpPost]
        [Route("api/Vendedors/create")]
        public HttpResponseMessage Create(Vendedor vendedor)
        {
            if (vendedor.CODIGO == 0 || (string.IsNullOrEmpty(vendedor.NOMBRE) ||
                string.IsNullOrEmpty(vendedor.APELLIDO) || string.IsNullOrWhiteSpace(vendedor.NUMERO_IDENTIFICACION))
                || vendedor.CODIGO_CIUDAD == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Verifique los datos, Nopueden ser vacios.");
            }
            else
            {
                try
                {
                    var vendedorFunction = new VendedorFunctions();
                    var ExisteCodigo = _vendedor.GetVendedorByCodigo(vendedor.CODIGO);
                    if (ExisteCodigo == null)
                    {
                        vendedorFunction.CreateVendedor(vendedor);
                    }
                    else
                    {
                        vendedorFunction.EditVendedor(vendedor);
                    }

                    var mesg = Request.CreateResponse(HttpStatusCode.Created);
                    mesg.Headers.Location = new Uri(Request.RequestUri + vendedor.CODIGO.ToString());

                    return mesg;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // POST: api/Vendedors/edit/{codigo}
        [HttpPost]
        [Route("api/Vendedors/edit/{codigo}")]
        public IHttpActionResult Edit(byte codigo, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (codigo != vendedor.CODIGO)
            {
                return BadRequest();
            }

            var vendedorUpdate = new VendedorFunctions();
            var result = vendedorUpdate.EditVendedor(vendedor);

            return StatusCode(HttpStatusCode.NotFound);
        }

        [HttpPost]
        [Route("api/Vendedors/delete/{codigo}")]
        public IHttpActionResult Delete(byte codigo)
        {
            var vendedor = _vendedor.GetVendedorByCodigo(codigo);

            if (vendedor == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _vendedor.DeleteVendedor(codigo);
                    return Ok(vendedor);
                }
                catch (Exception Ex)
                {
                    return InternalServerError(Ex);
                }
            }
        }
    }
}