using AjedrezBE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AjedrezUI
{
    public partial class Tablero : UserControl
    {
        public delegate void PictureBoxClick(object sender, PictureBox pic);
        public event PictureBoxClick ClickEnCuadrado;
        public Tablero()
        {
            InitializeComponent();
            
            Resetear();
            cuadrados = new PictureBox[8, 8];
            cuadrados[0, 0] = A1;
            cuadrados[1, 0] = B1;
            cuadrados[2, 0] = C1;
            cuadrados[3, 0] = D1;
            cuadrados[4, 0] = E1;
            cuadrados[5, 0] = F1;
            cuadrados[6, 0] = G1;
            cuadrados[7, 0] = H1;
            cuadrados[0, 1] = A2;
            cuadrados[1, 1] = B2;
            cuadrados[2, 1] = C2;
            cuadrados[3, 1] = D2;
            cuadrados[4, 1] = E2;
            cuadrados[5, 1] = F2;
            cuadrados[6, 1] = G2;
            cuadrados[7, 1] = H2;
            cuadrados[0, 2] = A3;
            cuadrados[1, 2] = B3;
            cuadrados[2, 2] = C3;
            cuadrados[3, 2] = D3;
            cuadrados[4, 2] = E3;
            cuadrados[5, 2] = F3;
            cuadrados[6, 2] = G3;
            cuadrados[7, 2] = H3;
            cuadrados[0, 3] = A4;
            cuadrados[1, 3] = B4;
            cuadrados[2, 3] = C4;
            cuadrados[3, 3] = D4;
            cuadrados[4, 3] = E4;
            cuadrados[5, 3] = F4;
            cuadrados[6, 3] = G4;
            cuadrados[7, 3] = H4;
            cuadrados[0, 4] = A5;
            cuadrados[1, 4] = B5;
            cuadrados[2, 4] = C5;
            cuadrados[3, 4] = D5;
            cuadrados[4, 4] = E5;
            cuadrados[5, 4] = F5;
            cuadrados[6, 4] = G5;
            cuadrados[7, 4] = H5;
            cuadrados[0, 5] = A6;
            cuadrados[1, 5] = B6;
            cuadrados[2, 5] = C6;
            cuadrados[3, 5] = D6;
            cuadrados[4, 5] = E6;
            cuadrados[5, 5] = F6;
            cuadrados[6, 5] = G6;
            cuadrados[7, 5] = H6;
            cuadrados[0, 6] = A7;
            cuadrados[1, 6] = B7;
            cuadrados[2, 6] = C7;
            cuadrados[3, 6] = D7;
            cuadrados[4, 6] = E7;
            cuadrados[5, 6] = F7;
            cuadrados[6, 6] = G7;
            cuadrados[7, 6] = H7;
            cuadrados[0, 7] = A8;
            cuadrados[1, 7] = B8;
            cuadrados[2, 7] = C8;
            cuadrados[3, 7] = D8;
            cuadrados[4, 7] = E8;
            cuadrados[5, 7] = F8;
            cuadrados[6, 7] = G8;
            cuadrados[7, 7] = H8;
            
        }

        


        public PictureBox[,] cuadrados;
        public AjedrezBE.POSICION posicionseleccionada;
        
        private void UserControl2_Load(object sender, EventArgs e)
        {
           
        }

        public void Resetear()
        {
            A8.Image = Ajedrez.Resources.BR;
            H8.Image = Ajedrez.Resources.BR;
            B8.Image = Ajedrez.Resources.BH;
            G8.Image = Ajedrez.Resources.BH;
            C8.Image = Ajedrez.Resources.BB;
            F8.Image = Ajedrez.Resources.BB;
            D8.Image = Ajedrez.Resources.BQ;
            E8.Image = Ajedrez.Resources.BK;
            A7.Image = Ajedrez.Resources.BP;
            B7.Image = Ajedrez.Resources.BP;
            C7.Image = Ajedrez.Resources.BP;
            D7.Image = Ajedrez.Resources.BP;
            E7.Image = Ajedrez.Resources.BP;
            F7.Image = Ajedrez.Resources.BP;
            G7.Image = Ajedrez.Resources.BP;
            H7.Image = Ajedrez.Resources.BP;

            A1.Image = Ajedrez.Resources.WR;
            H1.Image = Ajedrez.Resources.WR;
            B1.Image = Ajedrez.Resources.WH;
            G1.Image = Ajedrez.Resources.WH;
            C1.Image = Ajedrez.Resources.WB;
            F1.Image = Ajedrez.Resources.WB;
            D1.Image = Ajedrez.Resources.WQ;
            E1.Image = Ajedrez.Resources.WK;
            A2.Image = Ajedrez.Resources.WP;
            B2.Image = Ajedrez.Resources.WP;
            C2.Image = Ajedrez.Resources.WP;
            D2.Image = Ajedrez.Resources.WP;
            E2.Image = Ajedrez.Resources.WP;
            F2.Image = Ajedrez.Resources.WP;
            G2.Image = Ajedrez.Resources.WP;
            H2.Image = Ajedrez.Resources.WP;

            A6.Image = null;
            B6.Image = null;
            C6.Image = null;
            D6.Image = null;
            E6.Image = null;
            F6.Image = null;
            G6.Image = null;
            H6.Image = null;
            A5.Image = null;
            B5.Image = null;
            C5.Image = null;
            D5.Image = null;
            E5.Image = null;
            F5.Image = null;
            G5.Image = null;
            H5.Image = null;
            A4.Image = null;
            B4.Image = null;
            C4.Image = null;
            D4.Image = null;
            E4.Image = null;
            F4.Image = null;
            G4.Image = null;
            H4.Image = null;
            A3.Image = null;
            B3.Image = null;
            C3.Image = null;
            D3.Image = null;
            E3.Image = null;
            F3.Image = null;
            G3.Image = null;
            H3.Image = null;



        } 
        

        private void A8_Click(object sender, EventArgs e)
        {
            HizoClick(sender as PictureBox);
        }
        protected virtual void HizoClick(PictureBox pict)
        {
            ClickEnCuadrado?.Invoke(this, pict);
        }

        private void Tablerogroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
