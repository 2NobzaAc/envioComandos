using System;
using System.ComponentModel.DataAnnotations;

namespace comandos.data.model
{
    public class Comando
    {
        [Key]
        public int cm_id { get; set; }
        public string cm_unidad { get; set; }
        public string cm_comando { get; set; }
        public byte? cm_enviado { get; set; }
        public int? ua_id { get; set; }
        public DateTime? cm_fechains { get; set; }
    }
}
