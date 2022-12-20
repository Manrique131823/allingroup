using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Datos;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class InicioController : Controller
    {
        EmpresaDatos _EmpresaDatos = new EmpresaDatos();
        EmpresaModel _EmpresaModel = new EmpresaModel();
        SucursalModel _SucursalModel = new SucursalModel();
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Listar_Empresas()
        {

            var oListar_Empresas = _EmpresaDatos.Listar_Empresas();
            return Json(new { data = oListar_Empresas });

        }

        public JsonResult Listar_Sucursales(string IdEmpresa)
        {

            _EmpresaModel.IdEmpresa =Convert.ToInt32(IdEmpresa);

            var oListar_Sucursal = _EmpresaDatos.Listar_Sucursales(_EmpresaModel);
            return Json(new { data = oListar_Sucursal });

        }


        public JsonResult Listar_Deposito(string IdSucursal)
        {

            _SucursalModel.IdSucursal = Convert.ToInt32(IdSucursal);

            var oListar_Deposito = _EmpresaDatos.Listar_Deposito(_SucursalModel);
            return Json(new { data = oListar_Deposito });

        }




        [HttpPost("~/Inicio/Registrar_Articulo_Deposito")]
        public JsonResult Registrar_Articulo_Deposito([FromBody] DepositoModel oDeposito)
        {
            var respuesta = true;

            respuesta = _EmpresaDatos.Registrar_Articulo_Deposito(oDeposito);
            return Json(respuesta);


        }



        [HttpPost("~/Inicio/Registrar_Empresa")]
        public JsonResult Registrar_Empresa([FromBody] EmpresaModel oEmpresaModel)
        {
            var respuesta = true;

            respuesta = _EmpresaDatos.Registrar_Empresa(oEmpresaModel);
            return Json(respuesta);


        }

        [HttpPost("~/Inicio/Registrar_Sucursal")]
        public JsonResult Registrar_Sucursal([FromBody] SucursalModel oSucursal)
        {
            var respuesta = true;

            respuesta = _EmpresaDatos.Registrar_Sucursal(oSucursal);
            return Json(respuesta);


        }
    }
}
