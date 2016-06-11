using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServices.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return @"Data Source=(local);Initial Catalog=BDFortaleza;Integrated Security=SSPI;";
            }
        }
    }
}