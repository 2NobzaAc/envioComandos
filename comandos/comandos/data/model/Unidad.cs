using System;
using System.ComponentModel.DataAnnotations;

namespace comandos.data.model
{
    public class Unidad
    {
        [Key]
        public int un_id { get; set; }
        public short tpm_id { get; set; }
        public int? eu_id { get; set; }
        public string un_min { get; set; }
        public string un_unidadid { get; set; }
        public string un_IMEI { get; set; }
        public string un_ip { get; set; }
        public string un_correo { get; set; }
        public int? pl_id { get; set; }
        public int? un_frecuencia { get; set; }
        public bool? un_distancia { get; set; }
        public DateTime? un_fechains { get; set; }
        public short? un_GMT { get; set; }
        public string un_observacion { get; set; }
        public DateTime? un_fecha_bateria { get; set; }
    }
}
