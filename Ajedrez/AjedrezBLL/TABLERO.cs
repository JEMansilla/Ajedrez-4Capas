using AjedrezBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AjedrezBLL
{
    public class TABLERO:IDisposable
    {
        public static bool ValidarPosicion(AjedrezBE.POSICION pos)
        {
            return pos.X >=0 && pos.X<8 && pos.Y >=0 && pos.Y<8;
        }
        public static bool EstaVacio(AjedrezBE.TABLERO tab,AjedrezBE.POSICION pos)
        {
            return tab[pos] == null;
        }
        public void AgregarPiezasIniciales(AjedrezBE.TABLERO tab)
        {
            tab[0, 0] = new AjedrezBE.TORRE(true);
            tab[7, 0] = new AjedrezBE.TORRE(true);
            tab[1, 0] = new AjedrezBE.CABALLO(true);
            tab[6, 0] = new AjedrezBE.CABALLO(true);
            tab[2, 0] = new AjedrezBE.ALFIL(true);
            tab[5, 0] = new AjedrezBE.ALFIL(true);
            tab[3, 0] = new AjedrezBE.REINA(true);
            tab[4, 0] = new AjedrezBE.REY(true);

            for(int i = 0; i < 8; i++)
            {
                tab[i, 1] = new AjedrezBE.PEON(true);
                tab[i, 6] = new AjedrezBE.PEON(false);
            }



            tab[0, 7] = new AjedrezBE.TORRE(false);
            tab[7, 7] = new AjedrezBE.TORRE(false);
            tab[1, 7] = new AjedrezBE.CABALLO(false);
            tab[6, 7] = new AjedrezBE.CABALLO(false);
            tab[2, 7] = new AjedrezBE.ALFIL(false);
            tab[5, 7] = new AjedrezBE.ALFIL(false);
            tab[4, 7] = new AjedrezBE.REY(false);
            tab[3, 7] = new AjedrezBE.REINA(false);

        }
        public AjedrezBE.TABLERO InicializarTablero()
        {
            AjedrezBE.TABLERO tablero = new AjedrezBE.TABLERO();
            AgregarPiezasIniciales(tablero);
            return tablero;         
        }

        public IEnumerable<AjedrezBE.POSICION> PosicionesPiezas(AjedrezBE.TABLERO tab)
        {
            for (int i = 0; i<8; i++)
            {
                for (int j = 0; j<8; j++)
                {
                    AjedrezBE.POSICION posicion = new AjedrezBE.POSICION(i, j);
                    if (!TABLERO.EstaVacio(tab, posicion))
                    {
                        yield return posicion;
                    }
                }
            }
        }

        public IEnumerable<AjedrezBE.POSICION> PosicionesPiezasDeJugador(bool Color,  AjedrezBE.TABLERO tab)
        {
            return PosicionesPiezas(tab).Where(pos => tab[pos].Blanca == Color);
        }

        public bool HayJaque(AjedrezBE.JUGADOR jugadorenjaque, AjedrezBE.TABLERO tab, AjedrezBE.JUGADOR jugadoroponente)
        {
            return PosicionesPiezasDeJugador(jugadoroponente.Usablancos, tab).Any(pos =>
            {

                AjedrezBE.PIEZA pieza = tab[pos];
                PIEZA piezabll;
                if (pieza.Tipo == AjedrezBE.TipoPieza.ALFIL)
                {
                    piezabll = new ALFIL();
                }
                else if (pieza.Tipo == AjedrezBE.TipoPieza.TORRE)
                {
                    piezabll = new TORRE();
                }
                else if (pieza.Tipo == AjedrezBE.TipoPieza.CABALLO)
                {
                    piezabll = new CABALLO();
                }
                else if (pieza.Tipo == AjedrezBE.TipoPieza.REY)
                {
                    piezabll = new REY();
                }
                else if (pieza.Tipo == AjedrezBE.TipoPieza.REINA)
                {
                    piezabll = new REINA();
                }
                else
                {
                    piezabll = new PEON();
                }

                return piezabll.PuedeCapturarRey(pos, tab);
            });
        }


        public AjedrezBE.TABLERO Copiar(AjedrezBE.TABLERO tab)
        {
            AjedrezBE.TABLERO copia = new AjedrezBE.TABLERO();
            foreach (AjedrezBE.POSICION pos in PosicionesPiezas(tab))
            {
                copia[pos] = tab[pos].Copiar();
            }
            return copia;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AjedrezBE.POSICION ObtenerPosicionPassant(bool Color, AjedrezBE.TABLERO tab)
        {
            return tab.posicionespassantporcolor[Color];
        }

        public void EstablecerPosicionPassant(bool Color, AjedrezBE.POSICION pos, AjedrezBE.TABLERO tab)
        {
            tab.posicionespassantporcolor[Color] = pos;
        }

        public AjedrezBE.CONTEOPIEZA ContarPiezas(AjedrezBE.TABLERO tab)
        {
            AjedrezBE.CONTEOPIEZA conteo = new AjedrezBE.CONTEOPIEZA();
            using (CONTEOPIEZA conteobll = new CONTEOPIEZA())
            {
                foreach (AjedrezBE.POSICION pos in PosicionesPiezas(tab))
                {
                    AjedrezBE.PIEZA pieza = tab[pos];
                    conteobll.Incrementar(pieza.Blanca, pieza.Tipo, conteo);
                }
            }
            return conteo;
            
        }

        public bool InsuficienciaMaterial(AjedrezBE.TABLERO tab)
        {

            AjedrezBE.CONTEOPIEZA conteo = ContarPiezas(tab);

            return ReyVsRey(conteo) || ReyAlfilVsRey(conteo) || ReyCaballoVsRey(conteo) || ReyAlfilVsReyAlfil(conteo, tab);
            
            
        }

        private static bool ReyVsRey(AjedrezBE.CONTEOPIEZA conteo)
        {
            return conteo.Total == 2;
        }

        private static bool ReyAlfilVsRey(AjedrezBE.CONTEOPIEZA conteo)
        {
            using (CONTEOPIEZA conteobll = new CONTEOPIEZA())
            {
                return conteo.Total == 3 && (conteobll.Blancas(AjedrezBE.TipoPieza.ALFIL,conteo) == 1 || conteobll.Negras(AjedrezBE.TipoPieza.ALFIL,conteo) == 1);
            }
            
        }

        private static bool ReyCaballoVsRey(AjedrezBE.CONTEOPIEZA conteo)
        {
            using (CONTEOPIEZA conteobll = new CONTEOPIEZA())
            {
                return conteo.Total == 3 && (conteobll.Blancas(AjedrezBE.TipoPieza.CABALLO, conteo) == 1 || conteobll.Negras(AjedrezBE.TipoPieza.CABALLO, conteo) == 1);
            }

        }

        private bool ReyAlfilVsReyAlfil(AjedrezBE.CONTEOPIEZA conteo, AjedrezBE.TABLERO tab)
        {
            if(conteo.Total != 4)
            {
                return false;
            }
            using (CONTEOPIEZA conteobll = new CONTEOPIEZA())
            {
                if(conteobll.Blancas(AjedrezBE.TipoPieza.ALFIL, conteo) != 1 || conteobll.Negras(AjedrezBE.TipoPieza.ALFIL, conteo) != 1)
                {
                    return false;
                }

                AjedrezBE.POSICION posalfilblanco = EncontrarPieza(true, TipoPieza.ALFIL, tab);
                AjedrezBE.POSICION posalfilnegro = EncontrarPieza(false, TipoPieza.ALFIL, tab);
                using(POSICION posbll = new POSICION())
                {
                    return posbll.DeterminarColor(posalfilblanco) == posbll.DeterminarColor(posalfilnegro);
                }
                
            }
        }
        private AjedrezBE.POSICION EncontrarPieza(bool Color, AjedrezBE.TipoPieza tipo, AjedrezBE.TABLERO tab)
        {
            return PosicionesPiezasDeJugador(Color, tab).First(pos => tab[pos].Tipo == tipo);

        }
    }


}