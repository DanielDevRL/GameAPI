using GameAPI.Models;
using GameAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Services
{
    public class GameService
    {
        private readonly AplicationDbContext _context;
        public GameService(AplicationDbContext context)
        {
            _context = context;
        }

        public CreateUserResponse CreateGame(List<User> users)
        {
            CreateUserResponse dataresponse = new CreateUserResponse();
            try
            {
                Random rdn = new Random();
                Game dataGame = new Game();

                dataGame.CodGame = rdn.Next(1000, 9999);
                dataGame.CrateGame = DateTime.Now;

                _context.Add(dataGame);
                _context.SaveChanges();

                int player = 0;
                foreach(User user in users)
                {
                    player = player + 1;

                    GameUsers gu = new GameUsers();
                    gu.CodGame = dataGame.CodGame;
                    gu.IdUser = _context.User.Where(p => p.UserName == user.UserName).FirstOrDefault().IdUSer;
                    gu.Player = "Player" + player;

                    _context.Add(gu);
                    _context.SaveChanges();

                    if (gu.Player == "Player1")
                    {
                        dataresponse.Player1 = new User();
                        dataresponse.Player1.IdUSer = gu.IdUser;
                        dataresponse.Player1.UserName = user.UserName;
                    }
                    else
                    {
                        dataresponse.Player2= new User();
                        dataresponse.Player2.IdUSer = gu.IdUser;
                        dataresponse.Player2.UserName = user.UserName;
                    }

                        

                }

                dataresponse.CodGame = dataGame.CodGame.ToString();
                dataresponse.RoundNumer = "1";
                dataresponse.message = "OK";
                return dataresponse;


            }
            catch (Exception ex)
            {
                dataresponse.message = ex.Message;
                return dataresponse;
            }

        }


    }
}
