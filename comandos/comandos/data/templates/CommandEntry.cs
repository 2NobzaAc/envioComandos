namespace comandos.data.templates
{
    public class CommandEntry
    {
        public string cm_unidad { get; set; }
        public string cm_comando { get; set; }
        public string cm_enviado { get; set; }

        public CommandEntry(string cm_unidad, string cm_comando, byte isSent)
        {
            this.cm_unidad = cm_unidad;
            this.cm_comando = cm_comando;
            this.cm_enviado = isSent >= 1? "Enviado":"Pendiente";
        }
    }
}
