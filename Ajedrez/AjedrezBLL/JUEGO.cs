using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AjedrezBLL
{
	public class JUEGO:IDisposable
	{
		public AjedrezBE.JUGADOR Oponente(AjedrezBE.JUEGO juego)
		{
			AjedrezBE.JUGADOR jugadoroponente;
            if (juego.jugadores[0] == juego.Turno)
            {
                jugadoroponente = juego.jugadores[1];
            }
            else
            {
                jugadoroponente = juego.jugadores[0];
            }
			return jugadoroponente;
        }
		public IEnumerable<AjedrezBE.MOVIMIENTO> MovimentosLegales(AjedrezBE.POSICION inicio, AjedrezBE.JUEGO juego)
		{
			if (TABLERO.EstaVacio(juego.Tablero, inicio) || juego.Tablero[inicio].Blanca != juego.Turno.Usablancos)
			{
				yield break;
			}
			AjedrezBE.PIEZA pieza = juego.Tablero[inicio];
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
			IEnumerable<AjedrezBE.MOVIMIENTO> posiblesmovimientos = piezabll.ObtenerMovimientos(inicio, juego.Tablero);
			using (AjedrezBLL.MOVIMIENTO_NORMAL movnbll = new MOVIMIENTO_NORMAL())
			{
				using (AjedrezBLL.MOVIMIENTO_PROMOCIONPEON movppbll = new MOVIMIENTO_PROMOCIONPEON())
				{
					using(AjedrezBLL.MOVIMIENTO_ENROQUE movenroquebll = new MOVIMIENTO_ENROQUE())
					{
						using(AjedrezBLL.MOVIMIENTO_DOBLEPEON movdoble = new MOVIMIENTO_DOBLEPEON())
						{
                            using (AjedrezBLL.MOVIMIENTO_ENPASSANT movpassantbll = new MOVIMIENTO_ENPASSANT())
							{
                                foreach (AjedrezBE.MOVIMIENTO mov in posiblesmovimientos)
                                {
                                    if (mov.Tipo == AjedrezBE.TipoMovimiento.Normal)
                                    {

                                        if (movnbll.MovimientoEsLegal(mov, juego))
                                        {
                                            yield return mov;
                                        }


                                    }
                                    else if (mov.Tipo == AjedrezBE.TipoMovimiento.PromocionPeon)
                                    {

                                        if (movppbll.MovimientoEsLegal(mov, juego))
                                        {
                                            yield return mov;
                                        }


                                    }
                                    else if (mov.Tipo == AjedrezBE.TipoMovimiento.EnroqueLadoReina || mov.Tipo == AjedrezBE.TipoMovimiento.EnroqueLadoRey)
                                    {
                                        if (movenroquebll.MovimientoEsLegal(mov, juego))
                                        {
                                            yield return mov;
                                        }
                                    }
                                    else if (mov.Tipo == AjedrezBE.TipoMovimiento.DoblePeon)
                                    {
                                        if (movdoble.MovimientoEsLegal(mov, juego))
                                        {
                                            yield return mov;
                                        }

                                    }
									else
									{
										if(movpassantbll.MovimientoEsLegal(mov,juego))
										{
											yield return mov;
										}
									}
                                }
                            }
                        
                        }
                    }
                    
                }
                
            }
			yield break;
			
        }

        public void RealizarMovimiento(AjedrezBE.MOVIMIENTO movimiento, AjedrezBE.JUEGO juego, MOVIMIENTO mov)
        {
			using(AjedrezBLL.TABLERO tabbll = new TABLERO())
			{
				tabbll.EstablecerPosicionPassant(juego.Turno.Usablancos, null, juego.Tablero);

            }
				
				mov.Ejecutar(movimiento, juego.Tablero);
				juego.Turno = Oponente(juego);
				DeterminarFinalJuego(juego);
			
        }

		public IEnumerable<AjedrezBE.MOVIMIENTO> MovimientosLegalesParaJugador(AjedrezBE.JUGADOR jugador, AjedrezBE.JUEGO juego)
		{
			using (TABLERO tablerobll = new TABLERO())
			{
				
				
				IEnumerable<AjedrezBE.MOVIMIENTO> posiblesmovimientos = tablerobll.PosicionesPiezasDeJugador(jugador.Usablancos, juego.Tablero).SelectMany(pos =>
				{
					AjedrezBE.PIEZA pieza = juego.Tablero[pos];
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

					using (piezabll)
					{
						return piezabll.ObtenerMovimientos(pos, juego.Tablero);
					}

				});
				using (MOVIMIENTO_NORMAL movim = new MOVIMIENTO_NORMAL())
				{
					return posiblesmovimientos.Where(mo => movim.MovimientoEsLegal(mo,juego));
						}
			}
		}

		private void DeterminarFinalJuego(AjedrezBE.JUEGO juego)
		{
			using (TABLERO tablerobll = new TABLERO())
			{
				if (!MovimientosLegalesParaJugador(juego.Turno, juego).Any())
				{

					if (tablerobll.HayJaque(juego.Turno, juego.Tablero, Oponente(juego)))
					{
						juego.Resultado = RESULTADO.Victoria(Oponente(juego));
					}
					else
					{
						juego.Resultado = RESULTADO.Empate(AjedrezBE.TipoFinalPartida.Empate);
					}

				}
				else if (tablerobll.InsuficienciaMaterial(juego.Tablero))
				{
					juego.Resultado = RESULTADO.Empate(AjedrezBE.TipoFinalPartida.InsuficienciaDeMaterial);
				}
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public bool ChequearJuegoFinalizado(AjedrezBE.JUEGO juego)
		{
			return juego.Resultado != null;
		}
	}
}