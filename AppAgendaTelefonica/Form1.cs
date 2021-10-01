using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAgendaTelefonica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Agenda a = new Agenda();
            a.Agregar(new Contacto { Nombre = "Hugo", Telefono = "1", Direccion = "Aqui", TipoTelefono = TiposTelefono.Casa });
            a.Agregar(new Contacto { Nombre = "Paco", Telefono = "2", Direccion = "Alla", TipoTelefono = TiposTelefono.Casa });
            a.Agregar(new Contacto { Nombre = "Luis", Telefono = "3", Direccion = "Aculla", TipoTelefono = TiposTelefono.Casa });
            dataGridView1.DataSource = a.Contactos;
        }
    }
}
