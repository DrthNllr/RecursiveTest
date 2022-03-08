using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ControlPlaza.Entities;
using ControlPlaza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControlPlaza.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class PlazaController : Controller
    {
        private IControlPlazaOperations helper;
        private IHttpContextAccessor accessor;
        private Guid LlaveUsuario;  //Para implementar la validación del cliente

        public PlazaController(IControlPlazaOperations Helper, IHttpContextAccessor Accessor)
        {
            this.helper = Helper;
            this.accessor = Accessor;
            LlaveUsuario = Guid.Empty;
        }

        [HttpGet("{id}")]
        public IActionResult ById(string id)
        {

            Plaza plaza = helper.RetrieveById(id);
            return plaza != null ? Ok(plaza) : NotFound();

        }
    }
}