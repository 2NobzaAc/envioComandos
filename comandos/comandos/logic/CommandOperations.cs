using comandos.data;
using comandos.data.model;
using System;
using System.Diagnostics;

namespace comandos.logic
{
    public static class CommandOperations
    {
        public static int SendCommand(int ua_id, string cm_unidad, string cm_comando)
        {
            using (var context = new ProtrackContext())
            {
                try
                {
                    UsuarioAplicacion userExists = context.UsuarioAplicacion.Find(ua_id);

                    if (userExists == null) return 0; //usuario no existe
                    
                    Comando nuevo = new Comando()
                    {
                        cm_comando = cm_comando,
                        cm_unidad = cm_unidad,
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
                    return -1; //error de red
                }
            }
        }
    }
}
