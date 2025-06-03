using comandos.data;
using comandos.data.model;
using comandos.data.templates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace comandos.logic
{
    public static class CommandOperations
    {
        public static int SendCommand(int ua_id, string cm_unidad, string cm_comando)
        {
            if (cm_unidad == null || cm_unidad.Trim() == "") return -3;
            if (cm_comando == null || cm_comando.Trim() == "") return -4;
            string normalizedunit = cm_unidad.ToUpper().Trim();
            string normalizedCommand = cm_comando.ToUpper().Trim();
            using (var context = new ProtrackContext())
            {
                try
                {
                    UsuarioAplicacion userExists = context.UsuarioAplicacion.Find(ua_id);

                    if (userExists == null) return 0; //usuario no existe

                    bool unitExists = context.Unidad.Where(un => un.un_unidadid == normalizedunit).Any();
                    if (!unitExists) return -1;
                    
                    Comando nuevo = new Comando()
                    {
                        cm_comando = normalizedCommand,
                        cm_unidad = normalizedunit,
                        ua_id = ua_id,
                        cm_enviado = 0,
                        cm_fechains = DateTime.Now
                    };

                    context.Comando.Add(nuevo);
                    context.SaveChanges();

                    return nuevo.cm_id;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return -2; //error de red
                }
            }
        }
        public static List<CommandEntry> GetSentCommands(List<int> sent)
        {
            List < CommandEntry > fetched = new List<CommandEntry>();
            if (sent.Count == 0) return fetched;
            
            using (var context = new ProtrackContext())
            {
                try
                {
                    var queriedCommands = context.Comando.Where(cm => sent.Contains(cm.cm_id)).Select(cm => new
                    {
                        cm.cm_comando,
                        cm.cm_unidad,
                        cm.cm_enviado
                    });

                    foreach (var command in queriedCommands)
                    {
                        fetched.Add(new CommandEntry(command.cm_unidad, command.cm_comando, (byte) command.cm_enviado));
                    }

                    return fetched;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return fetched; ; //error de red
                }
            }
        }
    }
}
