using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Datos
{
    public class EmpresaDatos
    {

      
        public List<EmpresaModel> Listar_Empresas()
        {
            var oListar_Empresa = new List<EmpresaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_empresas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListar_Empresa.Add(new EmpresaModel()
                        {
                            IdEmpresa = Convert.ToInt32(dr["IdEmpresa"]),
                            Nombre_empresa = Convert.ToString(dr["Nombre"]),
                            Direccion_empresa = Convert.ToString(dr["Direccion"]),

                        });
                    }

                }

                conexion.Close();
            }

            return oListar_Empresa;
        }


        public List<SucursalModel> Listar_Sucursales(EmpresaModel oEmpresamodel)
        {
            var oListar_Sucursal = new List<SucursalModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_sucursales", conexion);
                cmd.Parameters.AddWithValue("IdEmpresa", oEmpresamodel.IdEmpresa);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListar_Sucursal.Add(new SucursalModel()
                        {
                            IdSucursal = Convert.ToInt32(dr["IdSucursal"]),
                            Nombre_sucursal = Convert.ToString(dr["Nombre"]),
                        });
                    }

                }

                conexion.Close();
            }

            return oListar_Sucursal;
        }




        public List<DepositoModel> Listar_Deposito(SucursalModel oSucursalModel)
        {
            var oListar_Deposito = new List<DepositoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_deposito", conexion);
                cmd.Parameters.AddWithValue("IdSucursal", oSucursalModel.IdSucursal);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListar_Deposito.Add(new DepositoModel()
                        {
                            IdDeposito = Convert.ToInt32(dr["IdDeposito"]),
                            Nombre_articulo = Convert.ToString(dr["Nombre_articulo"]),
                            Cantidad = Convert.ToString(dr["Cantidad"]),
                        });
                    }

                }

                conexion.Close();
            }

            return oListar_Deposito;
        }




        public bool Registrar_Articulo_Deposito(DepositoModel oDeposito)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Articulo_Deposito", conexion);
                    cmd.Parameters.AddWithValue("IdSucursal", oDeposito.IdSucursal);
                    cmd.Parameters.AddWithValue("Nombre_articulo", oDeposito.Nombre_articulo);
                    cmd.Parameters.AddWithValue("Cantidad", oDeposito.Cantidad);
            
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


        public bool Registrar_Empresa(EmpresaModel oEmpresa)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Empresa", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oEmpresa.Nombre_empresa);
                    cmd.Parameters.AddWithValue("Direccion", oEmpresa.Direccion_empresa);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


        public bool Registrar_Sucursal(SucursalModel oSucursal)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Sucursal", conexion);
                    cmd.Parameters.AddWithValue("IdEmpresa", oSucursal.IdEmpresa);
                    cmd.Parameters.AddWithValue("Nombre", oSucursal.Nombre_sucursal);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
