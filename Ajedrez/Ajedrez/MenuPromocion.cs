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
    public partial class MenuPromocion : UserControl
    {
        public event Action<AjedrezBE.TipoPieza> PiezaSeleccionada;
        public MenuPromocion(AjedrezBE.JUGADOR jugador)
        {
            InitializeComponent();
            if (jugador.Usablancos)
            {
                pictureBox1.Image = Resources.WQ1;
                pictureBox2.Image = Resources.WR1;
                pictureBox3.Image = Resources.WH1;
                pictureBox4.Image = Resources.WB1;

            }
            else
            {
                pictureBox1.Image = Resources.BQ1;
                pictureBox2.Image = Resources.BR1;
                pictureBox3.Image = Resources.BH1;
                pictureBox4.Image = Resources.BB1;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PiezaSeleccionada?.Invoke(AjedrezBE.TipoPieza.REINA);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PiezaSeleccionada?.Invoke(AjedrezBE.TipoPieza.TORRE);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PiezaSeleccionada?.Invoke(AjedrezBE.TipoPieza.CABALLO);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PiezaSeleccionada?.Invoke(AjedrezBE.TipoPieza.ALFIL);
        }

        private void MenuPromocion_Load(object sender, EventArgs e)
        {

        }
    }
}
