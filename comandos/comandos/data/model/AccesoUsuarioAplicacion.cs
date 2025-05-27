using System;
using System.ComponentModel.DataAnnotations;

namespace comandos.data.model
{
    public class AccesoUsuarioAplicacion
    {
        [Key]
        public int aua_id { get; set; }
        public int? ua_id { get; set; }
        public int? ap_id { get; set; }
        public DateTime? aua_fechainicio { get; set; }
        public DateTime? aua_fechafin { get; set; }
        public short? aua_perfil { get; set; }
        public bool? aua_externo { get; set; }
    }
}
