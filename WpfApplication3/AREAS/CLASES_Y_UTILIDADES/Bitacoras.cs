using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.AREAS.CLASES_Y_UTILIDADES
{
     [DataContract]
    class Bitacoras
    {

        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Efectividad { get; set; }
        [DataMember]
        public string Motivo { get; set; }
        [DataMember(IsRequired = false)]
        public string Observaciones { get; set; }
        [DataMember(IsRequired = false)]
        public string Origen { get; set; }
        [DataMember(IsRequired = false)]
        public string FechaAccion { get; set; }
        [DataMember]
        public string Accion { get; set; }
        [DataMember(IsRequired = false)]
        public string NombreCamp { get; set; }
        [DataMember(IsRequired = false)]
        public string TipoInteraccion { get; set; }
        [DataMember]
        public string Agente { get; set; }
        [DataMember(IsRequired = false)]
        public string DuracionCall { get; set; }
        [DataMember(IsRequired = false)]
        public string FechaTerminoCall { get; set; }
        [DataMember(IsRequired = false)]
        public string FechaInicioCall { get; set; }
        [DataMember(IsRequired = false)]
        public string Destino { get; set; }
        [DataMember]
        public string DNI { get; set; }
    }
}
