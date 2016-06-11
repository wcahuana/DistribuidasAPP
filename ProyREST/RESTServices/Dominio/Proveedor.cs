using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTServices.Dominio
{
    [DataContract]
    public class Proveedor
    {
        [DataMember]
        public string Ruc { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember(IsRequired = false)]
        public string Telefono { get; set; }
        [DataMember(IsRequired = false)]
        public string Email { get; set; }
    }
}