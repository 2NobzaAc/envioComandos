using comandos.data;
using comandos.data.model;
using System;
using System.Diagnostics;
using System.Linq;

namespace comandos.logic
{
    public static class CommandOperations
    {
        public static int SendCommand(int ua_id, string cm_unidad, string cm_comando)
        {
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
    }
}
