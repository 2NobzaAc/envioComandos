using comandos.data;
using comandos.data.templates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comandos.logic
{
    public static class LogsOperations
    {
        public static List<LogResult> GetLogsByDate(string unidad, DateTime start, DateTime end, bool hasBackup = false)
        {
            List<LogResult> logs = new List<LogResult>();
            string normalizedInput = unidad.ToUpper();

            using (var context = new ProtrackContext())
            {
                try
                {
                    var query = context.LogDatos.Where(lo => lo.lo_fecha >= start && lo.lo_fecha <= end && lo.lo_equipo == normalizedInput).Select(lo => new
                    {
                        lo.lo_infohex,
                        lo.lo_infoascii,
                        lo.lo_ip,
                        lo.lo_fecha
                    }).ToList();
                    if (query.Count > 0) {
                        //se agregan los resultados de la búsqueda al valor de retorno
                        foreach (var item in query)
                        {
                            logs.Add(new LogResult(item.lo_infohex, item.lo_infoascii, item.lo_ip, item.lo_fecha));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return logs;
        }
    }
}
