using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNeat.src.GameLogic
{
    public class Bat : Obstacle
    {
        public const string DEFAULT_FOLDER_PATH = "assets/images/Bat";
        public Bat(float x, float y, float speed, float gameSpeed, string folderPath = DEFAULT_FOLDER_PATH)
                    : base(x, y, speed, gameSpeed, folderPath)
        {
        }
    }
}