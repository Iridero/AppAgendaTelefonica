using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgendaTelefonica
{
    public enum TiposTelefono { Casa, Celular, Trabajo }
    public class Contacto
    {
        
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public TiposTelefono TipoTelefono { get; set; }
    }
}
