using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApplication1.Datos
{
    public class Conexion
    {


        private string CadenaSQL = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
   }


        public string getCadenaSQL()
        {
            return CadenaSQL;
        }


    }
}
