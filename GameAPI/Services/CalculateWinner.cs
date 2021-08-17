using GameAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameAPI.Models;

namespace GameAPI.Services
{
    public class CalculateWinner
    {
        private readonly AplicationDbContext _context;

        public CalculateWinner(AplicationDbContext context)
        {
            _context = context;
        }

        public ResponseCalculateWinner WinnerRound(long codGame, int RoundNumber)
        {
            ResponseCalculateWinner cW = new ResponseCalculateWinner();

            try
            {
                var garmeUser = _context.GameUsers.Where(p => p.CodGame == codGame).ToList();

                int mP1 = 0;
                int mP2 = 0;

                string NamePlayer1 = "";
                string NamePlayer2 = "";

                int idPlayer1 = 0;
                int idPlayer2 = 0;

                var Round = _context.Round.Where(p => p.CodGame == codGame && p.RoundNumber == RoundNumber).ToList();
                foreach (GameUsers gu in garmeUser)
                {
                    if (gu.Player == "Player1")
                    {
                        mP1 = Round.Where(p => p.IdUSer == gu.IdUser).FirstOrDefault().IdMovement;
                        idPlayer1 = gu.IdUser;
                        NamePlayer1 = _context.User.Find(gu.IdUser).UserName;
                        continue;
                    }

                    if (gu.Player == "Player2")
                    {
                        mP2 = Round.Where(p => p.IdUSer == gu.IdUser).FirstOrDefault().IdMovement;
                        idPlayer2 = gu.IdUser;
                        NamePlayer2 = _context.User.Find(gu.IdUser).UserName;

                        continue;
                    }

                }

                // 1 Piedra
                // 2 Papel
                // 3 Tijera

                if (mP1 == mP2)
                {
                    cW.resultRount = new ResultRound();
                    cW.resultRount.CodGame = codGame;
                    cW.resultRount.IdRound = RoundNumber;
                    cW.resultRount.IdUser = 0;
                    cW.resultRount.Result = "Empate";
                    cW.message = "OK";



                }
                else
                {
                    // piedra - papel
                    if (mP1 == 1 && mP2 == 2)
                    {
                        cW.resultRount = new ResultRound();
                        cW.resultRount.CodGame = codGame;
                        cW.resultRount.IdRound = RoundNumber;
                        cW.resultRount.IdUser = idPlayer2;
                        cW.resultRount.Result = NamePlayer2;
                        cW.message = "OK";
                    }
                    // piedra - tijera
                    else if (mP1 == 1 && mP2 == 3)
                    {
                        cW.resultRount = new ResultRound();
                        cW.resultRount.CodGame = codGame;
                        cW.resultRount.IdRound = RoundNumber;
                        cW.resultRount.IdUser = idPlayer1;
                        cW.resultRount.Result = NamePlayer1;
                        cW.message = "OK";
                    }
                    // papel - piedra
                    else if (mP1 == 2 && mP2 == 1)
                    {
                        cW.resultRount = new ResultRound();
                        cW.resultRount.CodGame = codGame;
                        cW.resultRount.IdRound = RoundNumber;
                        cW.resultRount.IdUser = idPlayer1;
                        cW.resultRount.Result = NamePlayer1;
                        cW.message = "OK";
                    }
                    // papel -tijera
                    else if (mP1 == 2 && mP2 == 3)
                    {
                        cW.resultRount = new ResultRound();
                        cW.resultRount.CodGame = codGame;
                        cW.resultRount.IdRound = RoundNumber;
                        cW.resultRount.IdUser = idPlayer2;
                        cW.resultRount.Result = NamePlayer2;
                        cW.message = "OK";
                    }
                    // tijera-piedra
                    else if (mP1 == 3 && mP2 == 1)
                    {
                        cW.resultRount = new ResultRound();
                        cW.resultRount.CodGame = codGame;
                        cW.resultRount.IdRound = RoundNumber;
                        cW.resultRount.IdUser = idPlayer2;
                        cW.resultRount.Result = NamePlayer2;
                        cW.message = "OK";
                    }
                    // tijera - papel
                    else if (mP1 == 3 && mP2 == 2)
                    {
                        cW.resultRount = new ResultRound();
                        cW.resultRount.CodGame = codGame;
                        cW.resultRount.IdRound = RoundNumber;
                        cW.resultRount.IdUser = idPlayer1;
                        cW.resultRount.Result = NamePlayer1;
                        cW.message = "OK";
                    }
                }

                cW.typeReponse = 1;
                _context.Add(cW.resultRount);
                _context.SaveChanges();


                return cW;

            }
            catch (Exception ex)
            {
                cW.message = ex.Message;
                cW.typeReponse = 0;

                return cW;
            }
        }

        public ResponseWinnerGame WinnerGame(int iduser, long Codgame)
        {
            ResponseWinnerGame Wg = new ResponseWinnerGame();

            try
            {
                int countWinner = _context.ResultRound.Where(p => p.CodGame == Codgame && p.IdUser == iduser).ToList().Count;

                if(countWinner >= 3)
                {
                    Wg.message = "Ganador";
                    Wg.UserName = _context.User.Where(p => p.IdUSer == iduser).First().UserName;
                }
                else
                {
                    Wg.message = "Siguiente";
                }

                Wg.TypeRespose = 1;

                return Wg;


            }
            catch (Exception ex)
            {
                Wg.message = ex.Message;
                Wg.TypeRespose = 0;
                return Wg;
            }
        }

    }
}
