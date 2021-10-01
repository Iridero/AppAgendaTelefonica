using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgendaTelefonica
{
    public class Agenda
    {
        public delegate void ActualizarLista();
        public event ActualizarLista ListaActualizada;
        public List<Contacto> Contactos { get; set; }
        public void Agregar(Contacto contacto)
        {
            if (Contactos == null)
            {
                Contactos = new();
            }
            Contactos.Add(contacto);
            ListaActualizada?.Invoke();
        }
        public void Eliminar(Contacto contacto)
        {
            if (Contactos==null)
            {
                throw new ApplicationException("La lista no existe");
            }
            if(Contactos.Remove(contacto))
            {
                ListaActualizada?.Invoke();
            }
        }
    }
}
