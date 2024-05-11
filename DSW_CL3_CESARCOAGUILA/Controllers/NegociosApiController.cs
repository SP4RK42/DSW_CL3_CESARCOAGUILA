using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DSW_CL3_CESARCOAGUILA.Models;
using DSW_CL3_CESARCOAGUILA.Repositorio.DAO;

namespace DSW_CL3_CESARCOAGUILA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegociosApiController : ControllerBase
    {
        [HttpGet("ListarProveedores")]
        public async Task<ActionResult<List<Proveedor>>> ListarProveedores()
        {
            var lista = await Task.Run(() => new proveedorDAO().ListarProveedores());
            return Ok(lista);
        }

        [HttpGet("ListarPaises")]
        public async Task<ActionResult<List<Pais>>> ListarPaises()
        {
            var lista = await Task.Run(() => new paisDAO().ListarPaises());
            return Ok(lista);
        }

        [HttpPost("InsertarProveedor")]
        public async Task<ActionResult<string>> InsertarProveedor(Proveedor reg)
        {
            var mensaje = await Task.Run(() => new proveedorDAO().InsertarProveedor(reg));
            return Ok(mensaje);
        }

        [HttpPut("ActualizarProveedor")]
        public async Task<ActionResult<string>> ActualizarProveedor(Proveedor reg)
        {
            var mensaje = await Task.Run(() => new proveedorDAO().ActualizarProveedor(reg));
            return Ok(mensaje);
        }

        [HttpGet("getProveedor/{id}")]
        public async Task<ActionResult<List<Proveedor>>> getProveedor(int id)
        {
            var lista = await Task.Run(() => new proveedorDAO().getProveedor(id));
            return Ok(lista);
        }

        [HttpDelete("EliminarProveedor/{id}")]
        public async Task<ActionResult<string>> EliminarProveedor(int id)
        {
            var mensaje = await Task.Run(() => new proveedorDAO().EliminarProveedor(id));
            return Ok(mensaje);
        }
    }
}
