using GameLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class App : IApp
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<App> _logger;
        private readonly IGame _game;
        /// <summary>
        /// constructor get injected dependencies
        /// </summary>
        /// <param name="logger">logger for application</param>
        /// <param name="config">connection to appsetting.json</param>
        /// <param name="game">game dependency</param>
        public App(ILogger<App> logger, IConfiguration config, IGame game)
        {
            _logger = logger;
            _configuration = config;
            _game = game;   
        }

        /// <summary>
        /// This is used as an alt main method as dependency injection & logging configured in progam.cs
        /// </summary>
        public void Run()
        {
            _logger.LogInformation("LOG: App.Run");
            _game.StartGame();

            
        }
    }
}



//testing config communicates with appsettings.json
//for (int i = 0; i < _configuration.GetValue<int>("LoopCount"); i++)
//{
//    _logger.LogInformation("LOG: Run method - {RunNumber}", i);
//}