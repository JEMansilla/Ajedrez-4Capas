using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajedrez
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjedrezBLL.JUGADOR jug = new AjedrezBLL.JUGADOR();
            AjedrezBE.JUGADOR jugador = jug.IniciarSesion(textBox1.Text, textBox2.Text);
            if(jugador == null)
            {
                MessageBox.Show("El usuario o contraseña son incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                jug = null;
                GC.Collect();
            }
            else
            {
                MessageBox.Show("Inicio de sesión exitoso","Bienvenido", MessageBoxButtons.OK);
                if(Form1.jugador1 == null)
                {
                    Form1.jugador1 = jugador;
                }
                else
                {
                    Form1.jugador2 = jugador;
                }
                jug = null;
                GC.Collect();

                DialogResult = DialogResult.OK;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AjedrezBLL.JUGADOR jug = new AjedrezBLL.JUGADOR();
            if(textBox3.Text == textBox5.Text)
            {
                if(jug.Registrar(textBox4.Text, textBox3.Text) == 1)
                {
                    MessageBox.Show("Registrado exitosamente", " ", MessageBoxButtons.OK);
                    jug = null;
                    GC.Collect();
                }
                else
                {
                    MessageBox.Show("El nombre de usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jug = null;
                    GC.Collect();
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                jug = null;
                GC.Collect();
            }


        }
    }
}
