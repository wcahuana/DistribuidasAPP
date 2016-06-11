using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTServices.Dominio
{
    [DataContract]
    public class Bitacoras
    {
    
        [DataMember]
        public String ID { get; set; }
        [DataMember]
        public String Efectividad { get; set; }
        [DataMember]
        public String Motivo { get; set; }
        [DataMember(IsRequired = false)]
        public String Observaciones { get; set; }
        [DataMember(IsRequired = false)]
        public String Origen { get; set; }
        [DataMember(IsRequired = false)]
        public String FechaAccion { get; set; }
        [DataMember]
        public String Accion { get; set; }
        [DataMember(IsRequired = false)]
        public String NombreCamp { get; set; }
        [DataMember(IsRequired = false)]
        public String TipoInteraccion { get; set; }
        [DataMember]
        public String Agente { get; set; }
        [DataMember(IsRequired = false)]
        public String DuracionCall { get; set; }
        [DataMember(IsRequired = false)]
        public String FechaTerminoCall { get; set; }
        [DataMember(IsRequired = false)]
        public String FechaInicioCall { get; set; }
        [DataMember(IsRequired = false)]
        public String Destino { get; set; }
        [DataMember]
        public String DNI { get; set; }

    }
}