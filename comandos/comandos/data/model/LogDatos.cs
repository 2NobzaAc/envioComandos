using System;
using System.ComponentModel.DataAnnotations;

namespace comandos.data.model
{
    public class LogDatos
    {
        [Key]
        public int lo_id { get; set; }
        public string lo_equipo { get; set; }
        public string lo_infohex { get; set; }
        public string lo_infoascii { get; set; }
        public string lo_ip { get; set; }
        public DateTime? lo_fecha { get; set; }
    }
}
