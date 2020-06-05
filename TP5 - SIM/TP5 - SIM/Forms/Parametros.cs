﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP5___SIM.Clases;

namespace TP5___SIM
{
    public partial class Parametros : Form
    {
        Datos oDatos = new Datos();

        public Parametros(Datos datos)
        {
            InitializeComponent();
            oDatos = datos;

            CargarTabla();
        }


        private void CargarTabla()
        {
            dgvDistDestinoCliente.Rows.Clear();

            dgvDistDestinoCliente.Rows.Add("Comprar", 0);
            dgvDistDestinoCliente.Rows.Add("Entregar Reloj", 0);
            dgvDistDestinoCliente.Rows.Add("Retirar Reloj", 0);
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                double tiempo = double.Parse(txtTiempo.Text);
                int iteraciones = int.Parse(txtIteraciones.Text);

                int desde = int.Parse(txtDesde.Text);
                double hasta = double.Parse(txtHasta.Text);

                double llegClienteA = double.Parse(txtLlegadaA.Text);
                double llegClienteB = double.Parse(txtLlegadaB.Text);

                double tiempoVentaA = double.Parse(txtTiempoVentaA.Text);
                double tiempoVentaB = double.Parse(txtTiempoVentaB.Text);

                double tiempoRepA = double.Parse(txtTiempoRepA.Text);
                double tiempoRepB = double.Parse(txtTiempoRepB.Text);

                double tiempoRepIni = double.Parse(txtInicialRep.Text);

                List<double> probAcumulada = new List<double>();

                double aux = 0;

                for (int i = 0; i < dgvDistDestinoCliente.Rows.Count; i++)
                {
                    aux = Convert.ToDouble(dgvDistDestinoCliente.Rows[i].Cells[2].Value);

                    probAcumulada.Add(aux);
                }

                oDatos.CargarDatos(tiempo, iteraciones, desde, hasta, probAcumulada, llegClienteA, llegClienteB, tiempoVentaA, tiempoVentaB, tiempoRepA, tiempoRepB, tiempoRepIni);

                MessageBox.Show("La carga de datos se ha realizado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ingrese todos los parámetros requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }


        private bool ValidarCampos()
        {
            if (txtTiempo.Text == "" || txtIteraciones.Text == "" || txtDesde.Text == "" || txtHasta.Text == "" || txtLlegadaA.Text == "" || txtLlegadaB.Text == "" || txtTiempoVentaA.Text == "" || txtTiempoVentaB.Text == "" || txtTiempoRepA.Text == "" || txtTiempoRepB.Text == "" || txtInicialRep.Text == "")
            {
                return false;
            }
            return true;
        }


        private void dgvDistDestinoCliente_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double aux = 0;

            for (int i = 0; i < dgvDistDestinoCliente.Rows.Count; i++)
            {
                aux += double.Parse(dgvDistDestinoCliente.Rows[i].Cells[1].Value.ToString());

                if (aux > 1)
                {
                    MessageBox.Show("La suma de las probabilidades no debe ser mayor a 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    break;
                }
                else
                {
                    dgvDistDestinoCliente.Rows[i].Cells[2].Value = aux;
                }
            }
        }


        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtTiempo.Text = "";
            txtIteraciones.Text = "";
            txtDesde.Text = "";
            txtHasta.Text = "";
            txtLlegadaA.Text = "";
            txtLlegadaB.Text = "";
            txtTiempoVentaA.Text = "";
            txtTiempoVentaB.Text = "";
            txtTiempoRepA.Text = "";
            txtTiempoRepB.Text = "";
            txtInicialRep.Text = "";

            CargarTabla();

            txtTiempo.Focus();
        }


        private void validarDouble(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }


        private void validarEntero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtIteraciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarEntero(sender, e);
        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarEntero(sender, e);
        }

        private void txtHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtLlegadaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtLlegadaB_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtTiempoVentaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtTiempoVentaB_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtTiempoRepA_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtTiempoRepB_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }

        private void txtInicialRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDouble(sender, e);
        }
    }
}