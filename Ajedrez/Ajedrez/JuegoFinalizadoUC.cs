using AjedrezBE;
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
    public partial class JuegoFinalizadoUC : UserControl
    {
        public event Action<Opcion> OpcionSeleccionada;
        public JuegoFinalizadoUC(AjedrezBE.JUEGO juego)
        {
            InitializeComponent();
            AjedrezBE.RESULTADO resultado = juego.Resultado;
            texto_ganador.Text = EstablecerGanador(resultado.Ganador);
            texto_razon.Text = EstablecerRazon(resultado.Razon, juego.Turno);
        }

        private void JuegoFinalizadoUC_Load(object sender, EventArgs e)
        {

        }

        private static string EstablecerGanador(AjedrezBE.JUGADOR jugador)
        {
            return jugador.Nombre + " GANA";
        }
        private static string EstablecerRazon(AjedrezBE.TipoFinalPartida razon, AjedrezBE.JUGADOR jugadorturno)
        {
            if(razon == AjedrezBE.TipoFinalPartida.Empate)
            {
                return "EMPATE" ;
            }
            else if(razon == AjedrezBE.TipoFinalPartida.JaqueMate)
            {
                return "JAQUE MATE";
            }
            else if (razon== AjedrezBE.TipoFinalPartida.ReglaDe50Movimientos)
            {
                return "REGLA DE LOS 50 MOVIMIENTOS";
            }
            else if (razon == AjedrezBE.TipoFinalPartida.InsuficienciaDeMaterial)
            {
                return "INSUFICIENCIA DE MATERIAL";
            }
            else
            {
                return "TRIPLE REPETICIÓN";
            }
        }
        private void boton_reiniciar_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada?.Invoke(Opcion.Reiniciar);
        }

        private void boton_salir_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada?.Invoke(Opcion.Salir);
        }

    }
}
