using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Core
{
    internal class GameLoseHandler 
    {
        private readonly LosePanel _losePanel;
        private readonly IGameLoop _gameLoop;
        public GameLoseHandler(LosePanel losePanel, IGameLoop gameLoop)
        {
            _losePanel = losePanel;
            _gameLoop = gameLoop;
        }
        public void OnGameLose()
        {
            _losePanel.Open();
            _gameLoop.StopGame();
        }
    }
    internal class GameWinHandler 
    {
        private readonly WinPanel _winPanel;
        private readonly IGameLoop _gameLoop;
        public GameWinHandler(WinPanel winPanel, IGameLoop gameLoop)
        {
            _winPanel = winPanel;
            _gameLoop = gameLoop;
        }
        public void OnGameWin()
        {

            _winPanel.Open();
            _gameLoop.StopGame();
        }
    }
}
