﻿using System;
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
        Agenda a;
        private void Form1_Load(object sender, EventArgs e)
        {
            a = new Agenda();
            a.Agregar(new Contacto { Nombre = "Hugo", Telefono = "1", Direccion = "Aqui", TipoTelefono = TiposTelefono.Casa });
            a.Agregar(new Contacto { Nombre = "Paco", Telefono = "2", Direccion = "Alla", TipoTelefono = TiposTelefono.Casa });
            a.Agregar(new Contacto { Nombre = "Luis", Telefono = "3", Direccion = "Aculla", TipoTelefono = TiposTelefono.Casa });
            dtgAgenda.DataSource = a.Contactos;
            a.ListaActualizada += A_ListaActualizada;
        }

        private void A_ListaActualizada()
        {
            dtgAgenda.DataSource = null;
            var f = new DataGridViewColumn();
            
            dtgAgenda.AutoGenerateColumns = false;
            dtgAgenda.Columns.Add(new DataGridViewColumn()
            { 
                AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill,
                Name="Nombre",
                HeaderText="Nombre",
                DataPropertyName="Nombre"
            }
            )
                ;
            dtgAgenda.Columns.Add(new DataGridViewColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Name = "Direccion",
                HeaderText = "Dirección",
                DataPropertyName="Direccion"
            });
            dtgAgenda.Columns.Add(new DataGridViewColumn
            {
                Width = 150,
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName="Telefono"
            }) ;
            dtgAgenda.Columns.Add(new DataGridViewColumn
            {
                Width = 100,
                Name = "TipoTelefono",
                HeaderText = "Tipo Teléfono",
                DataPropertyName="TipoTelefono"
            });
            dtgAgenda.DataSource=a.Contactos;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }   

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoContacto f = new();
            if( f.ShowDialog() == DialogResult.OK)
            {
                a.Agregar(f.nuevo);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dtgAgenda.SelectedRows)
            {
                Contacto c = (Contacto)row.DataBoundItem;
                a.Eliminar(c);
            }
        }
    }
}
