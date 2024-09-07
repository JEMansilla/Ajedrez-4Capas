using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AjedrezBE;
using AjedrezUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Ajedrez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tablero1.Enabled = false;
            groupBox3.Hide();
            this.Controls.Add(contenedormenu);
            contenedormenu.Visible = false;
            timer1.Stop();
            timer1.Enabled = false;

        }

        public AjedrezBLL.TABLERO tablerobll = new AjedrezBLL.TABLERO();
        public AjedrezBE.POSICION posicionseleccionada = null;
        private Dictionary<AjedrezBE.POSICION, AjedrezBE.MOVIMIENTO> movimientos = new Dictionary<POSICION, MOVIMIENTO>();
        public static AjedrezBE.JUGADOR jugador1;
        public static AjedrezBE.JUGADOR jugador2;
        public AjedrezBE.JUEGO juegoprincipal;
        public AjedrezBLL.TABLERO tab = new AjedrezBLL.TABLERO();
        private PictureBox temporal = null;
        private AjedrezBLL.MOVIMIENTO_NORMAL movbllnormal = new AjedrezBLL.MOVIMIENTO_NORMAL();
        public Panel contenedormenu = new Panel();








        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            using(AjedrezBLL.JUGADOR jugbll = new AjedrezBLL.JUGADOR())
            {
               jugbll.Restore();
            }
            Form2 sesion = new Form2();
            if (sesion.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
                this.Enabled = true;
                label1.Text = jugador1.Nombre;
                label11.Text = jugador1.Victorias.ToString();
                label12.Text = jugador1.Derrotas.ToString();
                label21.Text = jugador1.Empates.ToString();
                label13.Text = Math.Round(jugador1.Promedio,2).ToString();
                label14.Text = Math.Round(jugador1.HorasJugadas,2).ToString();
            }
        }

        private void tablero1_Load(object sender, EventArgs e)
        {

        }

        private void tablero1_ClickEnCuadrado(object sender, PictureBox pic)
        {
            if (MenuExiste())
            {
                return;
            }
            int x = 0;
            int y = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero1.cuadrados[i, j] == pic)
                    {
                        x = i;
                        y = j;
                        i = 8;
                        j = 8;

                    }
                }
            }
            AjedrezBE.POSICION posicion = new POSICION(x, y);
            PictureBox picturebox = pic;

            if (posicionseleccionada == null)
            {
                SeleccionarPieza(posicion);
                temporal = picturebox;
            }
            else
            {
                SeleccionarMovimiento(posicion, picturebox);

            }
        }
        private void MostrarMovimientos()
        {
            Color color = Color.FromKnownColor(KnownColor.Aqua);
            foreach (AjedrezBE.POSICION fin in movimientos.Keys)
            {
                tablero1.cuadrados[fin.X, fin.Y].BackColor = color;
            }
        }

        private void EsconderMovimientos()
        {
            Color color1 = Color.FromKnownColor(KnownColor.BlanchedAlmond);
            Color color2 = Color.FromKnownColor(KnownColor.SaddleBrown);
            tablero1.cuadrados[0, 0].BackColor = color2;
            tablero1.cuadrados[0, 1].BackColor = color1;
            tablero1.cuadrados[0, 2].BackColor = color2;
            tablero1.cuadrados[0, 3].BackColor = color1;
            tablero1.cuadrados[0, 4].BackColor = color2;
            tablero1.cuadrados[0, 5].BackColor = color1;
            tablero1.cuadrados[0, 6].BackColor = color2;
            tablero1.cuadrados[0, 7].BackColor = color1;
            tablero1.cuadrados[1, 0].BackColor = color1;
            tablero1.cuadrados[1, 1].BackColor = color2;
            tablero1.cuadrados[1, 2].BackColor = color1;
            tablero1.cuadrados[1, 3].BackColor = color2;
            tablero1.cuadrados[1, 4].BackColor = color1;
            tablero1.cuadrados[1, 5].BackColor = color2;
            tablero1.cuadrados[1, 6].BackColor = color1;
            tablero1.cuadrados[1, 7].BackColor = color2;
            tablero1.cuadrados[2, 0].BackColor = color2;
            tablero1.cuadrados[2, 1].BackColor = color1;
            tablero1.cuadrados[2, 2].BackColor = color2;
            tablero1.cuadrados[2, 3].BackColor = color1;
            tablero1.cuadrados[2, 4].BackColor = color2;
            tablero1.cuadrados[2, 5].BackColor = color1;
            tablero1.cuadrados[2, 6].BackColor = color2;
            tablero1.cuadrados[2, 7].BackColor = color1;
            tablero1.cuadrados[3, 0].BackColor = color1;
            tablero1.cuadrados[3, 1].BackColor = color2;
            tablero1.cuadrados[3, 2].BackColor = color1;
            tablero1.cuadrados[3, 3].BackColor = color2;
            tablero1.cuadrados[3, 4].BackColor = color1;
            tablero1.cuadrados[3, 5].BackColor = color2;
            tablero1.cuadrados[3, 6].BackColor = color1;
            tablero1.cuadrados[3, 7].BackColor = color2;
            tablero1.cuadrados[4, 0].BackColor = color2;
            tablero1.cuadrados[4, 1].BackColor = color1;
            tablero1.cuadrados[4, 2].BackColor = color2;
            tablero1.cuadrados[4, 3].BackColor = color1;
            tablero1.cuadrados[4, 4].BackColor = color2;
            tablero1.cuadrados[4, 5].BackColor = color1;
            tablero1.cuadrados[4, 6].BackColor = color2;
            tablero1.cuadrados[4, 7].BackColor = color1;
            tablero1.cuadrados[5, 0].BackColor = color1;
            tablero1.cuadrados[5, 1].BackColor = color2;
            tablero1.cuadrados[5, 2].BackColor = color1;
            tablero1.cuadrados[5, 3].BackColor = color2;
            tablero1.cuadrados[5, 4].BackColor = color1;
            tablero1.cuadrados[5, 5].BackColor = color2;
            tablero1.cuadrados[5, 6].BackColor = color1;
            tablero1.cuadrados[5, 7].BackColor = color2;
            tablero1.cuadrados[6, 0].BackColor = color2;
            tablero1.cuadrados[6, 1].BackColor = color1;
            tablero1.cuadrados[6, 2].BackColor = color2;
            tablero1.cuadrados[6, 3].BackColor = color1;
            tablero1.cuadrados[6, 4].BackColor = color2;
            tablero1.cuadrados[6, 5].BackColor = color1;
            tablero1.cuadrados[6, 6].BackColor = color2;
            tablero1.cuadrados[6, 7].BackColor = color1;
            tablero1.cuadrados[7, 0].BackColor = color1;
            tablero1.cuadrados[7, 1].BackColor = color2;
            tablero1.cuadrados[7, 2].BackColor = color1;
            tablero1.cuadrados[7, 3].BackColor = color2;
            tablero1.cuadrados[7, 4].BackColor = color1;
            tablero1.cuadrados[7, 5].BackColor = color2;
            tablero1.cuadrados[7, 6].BackColor = color1;
            tablero1.cuadrados[7, 7].BackColor = color2;

        }

        private void Movimientos(IEnumerable<AjedrezBE.MOVIMIENTO> mov)
        {
            movimientos.Clear();
            foreach (AjedrezBE.MOVIMIENTO movi in mov)
            {
                movimientos[movi.Final] = movi;
            }
        }

        private void SeleccionarPieza(AjedrezBE.POSICION pos)
        {
            using (AjedrezBLL.JUEGO juegobll = new AjedrezBLL.JUEGO())
            {
                IEnumerable<AjedrezBE.MOVIMIENTO> movimientos = juegobll.MovimentosLegales(pos, juegoprincipal);
                if (movimientos.Any())
                {
                    posicionseleccionada = pos;
                    Movimientos(movimientos);
                    MostrarMovimientos();
                }
            }
        }
        private void SeleccionarMovimiento(AjedrezBE.POSICION pos, PictureBox pic)
        {
            posicionseleccionada = null;
            EsconderMovimientos();
            if (movimientos.TryGetValue(pos, out AjedrezBE.MOVIMIENTO mov))
            {
                if (mov.Tipo == TipoMovimiento.PromocionPeon)
                {
                    pic.Image = temporal.Image;
                    EjecutarPromocion(mov.Inicio, mov.Final);
                }
                else if (mov.Tipo == TipoMovimiento.Normal)
                {
                    EjecutarMovimiento(mov, new AjedrezBLL.MOVIMIENTO_NORMAL());
                    pic.Image = temporal.Image;
                }
                else if (mov.Tipo == TipoMovimiento.EnroqueLadoReina || mov.Tipo == TipoMovimiento.EnroqueLadoRey)
                {
                    MOVIMIENTO_ENROQUE movenroque = (MOVIMIENTO_ENROQUE)mov;
                    using (AjedrezBLL.MOVIMIENTO_ENROQUE movenroquebll = new AjedrezBLL.MOVIMIENTO_ENROQUE())
                    {
                        EjecutarMovimiento(movenroque, movenroquebll);
                    }
                    pic.Image = temporal.Image;
                    tablero1.cuadrados[movenroque.torrefinal.X, movenroque.torrefinal.Y].Image = tablero1.cuadrados[movenroque.torreinicio.X, movenroque.torreinicio.Y].Image;
                    tablero1.cuadrados[movenroque.torreinicio.X, movenroque.torreinicio.Y].Image = null;
                }
                else if (mov.Tipo == TipoMovimiento.DoblePeon)
                {
                    using (AjedrezBLL.MOVIMIENTO_DOBLEPEON movdoblebll = new AjedrezBLL.MOVIMIENTO_DOBLEPEON())
                    {
                        MOVIMIENTO_DOBLEPEON movdoble = (MOVIMIENTO_DOBLEPEON)mov;
                        EjecutarMovimiento(mov, movdoblebll);
                        pic.Image = temporal.Image;
                    }
                }
                //Agregar EnPassant
                else
                {
                    using (AjedrezBLL.MOVIMIENTO_ENPASSANT movpassantbll = new AjedrezBLL.MOVIMIENTO_ENPASSANT())
                    {
                        MOVIMIENTO_ENPASSANT movpassant = (MOVIMIENTO_ENPASSANT)mov;
                        EjecutarMovimiento(movpassant, movpassantbll);
                        pic.Image = temporal.Image;
                        tablero1.cuadrados[movpassant.posicioncaptura.X, movpassant.posicioncaptura.Y].Image = null;
                    }
                }
                    temporal.Image = null;
                temporal = null;
                if (juegoprincipal.Turno.Usablancos)
                {
                    label20.Text = "BLANCO";
                    label20.BackColor = Color.White;
                    label20.ForeColor = Color.Black;
                }
                else
                {
                    label20.Text = "NEGRO";
                    label20.BackColor = Color.Black;
                    label20.ForeColor = Color.White;
                }
            }
        }
        private void EjecutarPromocion(AjedrezBE.POSICION inicio, AjedrezBE.POSICION final)
        {
            MenuPromocion promocionmenu = new MenuPromocion(juegoprincipal.Turno);
            contenedormenu.Controls.Add(promocionmenu);
            contenedormenu.Size = promocionmenu.Size;
            contenedormenu.Visible = true;
            contenedormenu.BringToFront();
            contenedormenu.Left = (this.ClientSize.Width - contenedormenu.Width) / 2;
            contenedormenu.Top = (this.ClientSize.Height - contenedormenu.Height) / 2;
            promocionmenu.PiezaSeleccionada += tipo =>
            {
                contenedormenu.Controls.Clear();
                contenedormenu.Hide();
                AjedrezBE.MOVIMIENTO_PROMOCIONPEON promov = new MOVIMIENTO_PROMOCIONPEON(inicio, final, tipo);
                if (juegoprincipal.Turno.Usablancos)
                {
                    if (tipo == TipoPieza.ALFIL)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.WB;
                    }
                    if (tipo == TipoPieza.TORRE)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.WR;
                    }
                    if (tipo == TipoPieza.CABALLO)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.WH;
                    }
                    if (tipo == TipoPieza.REINA)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.WQ;
                    }
                }
                else
                {
                    if (tipo == TipoPieza.ALFIL)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.BB;
                    }
                    if (tipo == TipoPieza.TORRE)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.BR;
                    }
                    if (tipo == TipoPieza.CABALLO)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.BH;
                    }
                    if (tipo == TipoPieza.REINA)
                    {
                        tablero1.cuadrados[final.X, final.Y].Image = Resources.BQ;
                    }
                }
                EjecutarMovimiento(promov, new AjedrezBLL.MOVIMIENTO_PROMOCIONPEON());
                
                
            };
            

        }
        private void EjecutarMovimiento(AjedrezBE.MOVIMIENTO mov, AjedrezBLL.MOVIMIENTO movbll)
        {
            using (AjedrezBLL.JUEGO juegobll = new AjedrezBLL.JUEGO())
            {
                juegobll.RealizarMovimiento(mov, juegoprincipal, movbll);
                if(juegobll.ChequearJuegoFinalizado(juegoprincipal))
                {
                    if(jugador1 != jugador2)
                    {
                        if (juegoprincipal.Resultado.Ganador.Nombre != "Nadie")
                        {
                            juegoprincipal.Resultado.Ganador.Victorias++;
                            if (juegoprincipal.Resultado.Ganador.Derrotas == 0)
                            {
                                juegoprincipal.Resultado.Ganador.Promedio = juegoprincipal.Resultado.Ganador.Victorias;
                            }
                            else
                            {
                                juegoprincipal.Resultado.Ganador.Promedio = (juegoprincipal.Resultado.Ganador.Victorias / juegoprincipal.Resultado.Ganador.Derrotas);
                            }

                            if (jugador1 == juegoprincipal.Resultado.Ganador)
                            {

                                jugador2.Derrotas++;
                                if (jugador2.Victorias == 0)
                                {
                                    jugador2.Promedio = jugador2.Derrotas;
                                }
                                else
                                {
                                    jugador2.Promedio = (jugador2.Victorias / jugador2.Derrotas);
                                }

                            }
                            else
                            {
                                jugador1.Derrotas++;
                                if (jugador1.Victorias == 0)
                                {
                                    jugador1.Promedio = jugador1.Derrotas;
                                }
                                else
                                {
                                    jugador1.Promedio = (jugador1.Victorias / jugador1.Derrotas);
                                }
                            }
                        }
                        else
                        {
                            jugador1.Empates++;
                            jugador2.Empates++;
                        }
                    }
                    
                    
                    timer1.Stop();
                    timer1.Enabled = false;
                    MostrarFinalJuego();
                }
               
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radio = new System.Windows.Forms.RadioButton();
            radio = sender as System.Windows.Forms.RadioButton;

            if (radio == radioButton1)
            {
                radioButton3.Checked = !radioButton1.Checked;
            }
            if (radio == radioButton2)
            {
                radioButton4.Checked = !radioButton2.Checked;
            }
            if (radio == radioButton3)
            {
                radioButton1.Checked = !radioButton3.Checked;
            }
            if (radio == radioButton4)
            {
                radioButton2.Checked = !radioButton4.Checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Form2 sesion = new Form2();
            if (sesion.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                button2.Enabled = false;
                button2.Hide();
                this.Enabled = true;
                label18.Text = jugador2.Nombre;
                label9.Text = jugador2.Victorias.ToString();
                label8.Text = jugador2.Derrotas.ToString();
                label23.Text = jugador2.Empates.ToString();
                label7.Text = Math.Round(jugador2.Promedio,2).ToString();
                label6.Text = Math.Round(jugador2.HorasJugadas,2).ToString();
                
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            if (jugador1 != null && jugador2 != null)
            {
                if (radioButton1.Checked && radioButton4.Checked)
                {
                    jugador1.Usablancos = true;
                    jugador2.Usablancos = false;
                }
                else if (radioButton2.Checked && radioButton3.Checked)
                {
                    jugador1.Usablancos = false;
                    jugador2.Usablancos = true;
                }
                else
                {
                    jugador1.Usablancos = true;
                    jugador2.Usablancos = false;
                }
                juegoprincipal = new AjedrezBE.JUEGO(jugador1, tablerobll.InicializarTablero());
                juegoprincipal.jugadores[1] = jugador2;
                if (juegoprincipal.jugadores[0].Usablancos == true)
                {
                    juegoprincipal.Turno = juegoprincipal.jugadores[0];
                    colorjugador1.Text = "BLANCO";
                    colorjugador2.Text = "NEGRO";
                    
                }
                else
                {
                    juegoprincipal.Turno = juegoprincipal.jugadores[1];
                    colorjugador2.Text = "BLANCO";
                    colorjugador1.Text = "NEGRO";

                }
                colorjugador1.Visible = true;
                colorjugador2.Visible = true;
                tablero1.Enabled = true;
                button1.Hide();
                button1.Enabled = false;
                groupBox3.Show();
                groupBox1.Hide();
                groupBox2.Hide();
            }

        }

        private bool MenuExiste()
        {
            return contenedormenu.Controls.Count != 0;
        }

        private void MostrarFinalJuego()
        {
            JuegoFinalizadoUC menufinaljuego = new JuegoFinalizadoUC(juegoprincipal);
            contenedormenu.Controls.Add(menufinaljuego);
            
            contenedormenu.Size = menufinaljuego.Size;
            contenedormenu.Visible = true;
            contenedormenu.BringToFront();
            contenedormenu.Left = (this.ClientSize.Width - contenedormenu.Width) / 2;
            contenedormenu.Top = (this.ClientSize.Height - contenedormenu.Height) / 2;

            menufinaljuego.OpcionSeleccionada += opcion =>
            {
                if (opcion == Opcion.Reiniciar)
                {
                    contenedormenu.Controls.Clear();
                    ReiniciarJuego();
                    contenedormenu.Hide();
                }
                else
                {
                    Application.Exit();
                }
            };
        }
        private void ReiniciarJuego()
        {
            EsconderMovimientos();
            movimientos.Clear();
                using (AjedrezBLL.TABLERO tablerobll = new AjedrezBLL.TABLERO())
            {
                juegoprincipal = new AjedrezBE.JUEGO(jugador1, tablerobll.InicializarTablero());
            }
            juegoprincipal.jugadores[1] = jugador2;
            if (juegoprincipal.jugadores[0].Usablancos)
            {
                juegoprincipal.Turno = juegoprincipal.jugadores[0];
            }
            else
            {
                juegoprincipal.Turno = juegoprincipal.jugadores[1];
            }
            tablero1.Resetear();
            label18.Text = jugador2.Nombre;
            label9.Text = jugador2.Victorias.ToString();
            label8.Text = jugador2.Derrotas.ToString();
            label23.Text = jugador2.Empates.ToString();
            label7.Text = Math.Round(jugador2.Promedio,2).ToString();
            label6.Text = Math.Round(jugador2.HorasJugadas,2).ToString();
            label1.Text = jugador1.Nombre;
            label11.Text = jugador1.Victorias.ToString();
            label12.Text = jugador1.Derrotas.ToString();
            label21.Text = jugador1.Empates.ToString();
            label13.Text = Math.Round(jugador1.Promedio,2).ToString();
            label14.Text = Math.Round(jugador1.HorasJugadas,2).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            double tiemposegundos = timer1.Interval;
            decimal tiempohoras = (decimal)tiemposegundos / (decimal)3600.0;
            jugador1.HorasJugadas += tiempohoras;
            jugador2.HorasJugadas += tiempohoras;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using(AjedrezBLL.JUGADOR jugbll = new AjedrezBLL.JUGADOR())
            {
                if(jugador1 != null && jugador2 != null)
                {
                    jugbll.GuardarEstadisticas(jugador1);
                    jugbll.GuardarEstadisticas(jugador2);
                    
                }
                jugbll.Backup();
            }

        }
    }
}
