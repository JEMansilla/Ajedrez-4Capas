using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    internal class Class1
    {
        /*private Dictionary<AjedrezBE.POSICION, AjedrezBE.MOVIMIENTO> movimientos = new Dictionary<POSICION, MOVIMIENTO>();
        public Tablero()
        {
            InitializeComponent();
        }

        public AjedrezBE.JUEGO juego;
        private AjedrezBLL.JUEGO juegobll = new AjedrezBLL.JUEGO();

        private PictureBox temporal = null;

        public PictureBox[,] cuadrados;
        public AjedrezBE.POSICION posicionseleccionada;

        private void UserControl2_Load(object sender, EventArgs e)
        {
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

        private void Resetear()
        {
            A8.Image = Ajedrez.Resources.BR;
            H8.Image = Ajedrez.Resources.BR;
            B8.Image = Ajedrez.Resources.BH;
            G8.Image = Ajedrez.Resources.BH;
            C8.Image = Ajedrez.Resources.BB;
            F8.Image = Ajedrez.Resources.BB;
            D8.Image = Ajedrez.Resources.BK;
            E8.Image = Ajedrez.Resources.BQ;
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
            D1.Image = Ajedrez.Resources.WK;
            E1.Image = Ajedrez.Resources.WQ;
            A2.Image = Ajedrez.Resources.WP;
            B2.Image = Ajedrez.Resources.WP;
            C2.Image = Ajedrez.Resources.WP;
            D2.Image = Ajedrez.Resources.WP;
            E2.Image = Ajedrez.Resources.WP;
            F2.Image = Ajedrez.Resources.WP;
            G2.Image = Ajedrez.Resources.WP;
            H2.Image = Ajedrez.Resources.WP;
        }
        private void A8_Click_1(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cuadrados[i, j] == sender as PictureBox)
                    {
                        x = i;
                        y = j;
                    }
                }
            }


            PictureBox picturebox = sender as PictureBox;

            if (posicionseleccionada == null)
            {
                SeleccionarPieza(juego.Tablero.cuadrados[x, y]);
                temporal = picturebox;
            }
            else
            {
                SeleccionarMovimiento(juego.Tablero.cuadrados[x, y]);
                picturebox.Image = temporal.Image;
                temporal.Image = null;
                temporal = null;
            }

            //(temporal == null)
            {
                if(picturebox.Image != null)
                { 
                temporal = picturebox;
                }
            }
            else
            {
                picturebox.Image = temporal.Image;
                temporal.Image = null;
                temporal = null;
            }
           //
        }

        private void Movimientos(IEnumerable<AjedrezBE.MOVIMIENTO> mov)
        {
            movimientos.Clear();
            foreach (AjedrezBE.MOVIMIENTO movi in mov)
            {
                movimientos[movi.Final] = movi;
            }
        }

        private void MostrarMovimientos()
        {
            Color color = Color.FromKnownColor(KnownColor.Aqua);
            foreach (AjedrezBE.POSICION fin in movimientos.Keys)
            {
                cuadrados[fin.X, fin.Y].BackColor = color;
            }
        }

        private void EsconderMovimientos()
        {
            Color color1 = Color.FromKnownColor(KnownColor.BlanchedAlmond);
            Color color2 = Color.FromKnownColor(KnownColor.SaddleBrown);
            A1.BackColor = color2;
            A2.BackColor = color1;
            A3.BackColor = color2;
            A4.BackColor = color1;
            A5.BackColor = color2;
            A6.BackColor = color1;
            A7.BackColor = color2;
            A8.BackColor = color1;
            B1.BackColor = color1;
            B2.BackColor = color2;
            B3.BackColor = color1;
            B4.BackColor = color2;
            B5.BackColor = color1;
            B6.BackColor = color2;
            B7.BackColor = color1;
            B8.BackColor = color2;
            C1.BackColor = color2;
            C2.BackColor = color1;
            C3.BackColor = color2;
            C4.BackColor = color1;
            C5.BackColor = color2;
            C6.BackColor = color1;
            C7.BackColor = color2;
            C8.BackColor = color1;
            D1.BackColor = color1;
            D2.BackColor = color2;
            D3.BackColor = color1;
            D4.BackColor = color2;
            D5.BackColor = color1;
            D6.BackColor = color2;
            D7.BackColor = color1;
            D8.BackColor = color2;
            E1.BackColor = color2;
            E2.BackColor = color1;
            E3.BackColor = color2;
            E4.BackColor = color1;
            E5.BackColor = color2;
            E6.BackColor = color1;
            E7.BackColor = color2;
            E8.BackColor = color1;
            F1.BackColor = color1;
            F2.BackColor = color2;
            F3.BackColor = color1;
            F4.BackColor = color2;
            F5.BackColor = color1;
            F6.BackColor = color2;
            F7.BackColor = color1;
            F8.BackColor = color2;
            G1.BackColor = color2;
            G2.BackColor = color1;
            G3.BackColor = color2;
            G4.BackColor = color1;
            G5.BackColor = color2;
            G6.BackColor = color1;
            G7.BackColor = color2;
            G8.BackColor = color1;
            H1.BackColor = color1;
            H2.BackColor = color2;
            H3.BackColor = color1;
            H4.BackColor = color2;
            H5.BackColor = color1;
            H6.BackColor = color2;
            H7.BackColor = color1;
            H8.BackColor = color2;

        }

        private void SeleccionarPieza(AjedrezBE.POSICION pos)
        {
            IEnumerable<AjedrezBE.MOVIMIENTO> movimientos = juegobll.MovimentosLegales(pos, juego);
            if (movimientos.Any())
            {
                posicionseleccionada = pos;
                Movimientos(movimientos);
                MostrarMovimientos();
            }
        }
        private void SeleccionarMovimiento(AjedrezBE.POSICION pos)
        {
            posicionseleccionada = null;
            EsconderMovimientos();
            if (movimientos.TryGetValue(pos, out AjedrezBE.MOVIMIENTO mov))
            {
                EjecutarMovimiento(mov);
            }
        }

        private void EjecutarMovimiento(AjedrezBE.MOVIMIENTO mov)
        {
            juegobll.RealizarMovimiento(mov, juego);
        }*/
    }
}
