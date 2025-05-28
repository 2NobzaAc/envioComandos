using System;

namespace comandos.data.templates
{
    public class LogResult
    {
        public string lo_infoascii { get; set; }
        public string lo_ip { get; set; }
        public DateTime? lo_fecha { get; set; }

        public LogResult(string lo_infoascii, string lo_ip, DateTime? lo_fecha)
        {
            this.lo_infoascii = lo_infoascii;
            this.lo_ip = lo_ip;
            this.lo_fecha = lo_fecha;
        }
    }
}
