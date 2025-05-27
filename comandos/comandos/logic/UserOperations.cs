using comandos.data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comandos.logic
{
    public static class UserOperations
    {

        public static short Login(string usr, string con)
        {
            using (var context = new ProtrackContext())
            {
                try
                {
                    short? loginQuery = (from ua in context.UsuarioAplicacion
                                         join aua in context.AccesoUsuarioAplicacion on ua.ua_id equals aua.ua_id
                                         where ua.ua_usr == usr && ua.ua_con == con && aua.ap_id == 33
                                         select aua.aua_perfil).FirstOrDefault();
                    if (loginQuery != null) return (short)loginQuery;
                    else return -1;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return -2;
                }
            }
        }
    }
}
