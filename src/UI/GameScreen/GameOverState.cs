using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoNeat.src.UI.MainMenu;
using SoNeat.src.Utils;
using SplashKitSDK;

namespace SoNeat.src.UI.GameScreen
{
    public class GameOverState : IGameState
    {
        private GameScreenState _context;

        public GameOverState(GameScreenState context)
        {
            _context = context;
        }

        public void Update()
        {
            if (_context.Buttons!["RetryButton"].IsClicked())
            {
                GameScreenState gameScreen = new GameScreenState();
                gameScreen.EnvironmentSpawner = _context.EnvironmentSpawner;
                ScreenManager.Instance.SetState(gameScreen);
            }

            if (_context.Buttons!["MainMenuButton"].IsClicked())
            {
                MainMenuState mainMenuState = new MainMenuState();
                mainMenuState.EnvironmentSpawner = _context.EnvironmentSpawner;
                ScreenManager.Instance.SetState(mainMenuState);
            }
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(_context.UIBitmaps!["GameOver"], 305, 151);

            foreach (MyButton button in _context.Buttons!.Values)
            {
                button.Draw();
                if (button.IsHovered())
                {
                    SplashKit.DrawBitmap(_context.UIBitmaps!["ChooseArrow"], button.X - 40, button.Y);
                }
            }
        }
    }
}