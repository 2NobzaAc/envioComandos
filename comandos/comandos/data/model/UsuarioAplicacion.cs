using System;
using System.ComponentModel.DataAnnotations;

namespace comandos.data.model
{
    public class UsuarioAplicacion
    {
        [Key]
        public int ua_id { get; set; }
        public int? co_id { get; set; }
        public string ua_usr { get; set; }
        public string ua_con { get; set; }
        public string ua_conmd5 { get; set; }
        public short? ua_tiempocambio { get; set; }
        public DateTime? ua_fechaini { get; set; }
        public DateTime? ua_fechafin { get; set; }
    }
}
