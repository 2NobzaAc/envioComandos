using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comandos.data.model
{
    public class Perfil
    {
        [Key, Column(Order = 0)]
        public int per_id { get; set; }
        [Key, Column(Order = 1)]
        public short ap_id { get; set; }
        public string per_nombre { get; set; }
        public string per_descripcion { get; set; }
    }
}
