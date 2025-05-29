using comandos.data;
using System;
using System.Diagnostics;
using System.Linq;

namespace comandos.logic
{
    public static class UserOperations
    {

        public static int[] Login(string usr, string con)
        {
            using (var context = new ProtrackContext())
            {
                try
                {
                    var loginQuery = (from ua in context.UsuarioAplicacion
                                         join aua in context.AccesoUsuarioAplicacion on ua.ua_id equals aua.ua_id
                                         where ua.ua_usr == usr && ua.ua_con == con && aua.ap_id == 33 && ua.ua_fechafin == null && aua.aua_fechafin == null
                                         select new { aua.aua_perfil, ua.ua_id }).FirstOrDefault();
                    if (loginQuery != null) return new int[] { (int)loginQuery.aua_perfil, loginQuery.ua_id};
                    else return new int[] { -1, 0 };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new int[] { -2, 0 };
                }
            }
        }
    }
}
