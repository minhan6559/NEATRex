using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using SplashKitSDK;
using SoNeat.src.Utils;
using System.Text.RegularExpressions;

namespace SoNeat.src.GameLogic
{
    public enum ObstacleType
    {
        Crab,
        Spike,
        Hog,
        Bat
    }

    public class ObstacleFactory
    {
        private static readonly Random _random = new Random();
        public static Obstacle CreateObstacle(float gameSpeed, ObstacleType? type = null)
        {
            if (type == null)
            {
                // Randomly choose an obstacle type based on length of ObstacleType enum
                type = (ObstacleType)_random.Next(Enum.GetNames(typeof(ObstacleType)).Length);
            }

            string folderPath = Utility.NormalizePath("assets/images/" + type.ToString());
            float xSpawn = SplashKit.ScreenWidth() + 100;
            return type switch
            {
                ObstacleType.Crab => new Crab(xSpawn, 560, gameSpeed, gameSpeed, folderPath),
                ObstacleType.Bat => new Bat(xSpawn, CreateRandomBatY(), CreateRandomBatSpeed(gameSpeed), gameSpeed, folderPath),
                ObstacleType.Spike => new Spike(xSpawn, 583, gameSpeed, gameSpeed, folderPath),
                ObstacleType.Hog => new Hog(xSpawn, 459, gameSpeed, gameSpeed, folderPath),
                _ => throw new ArgumentException("Invalid obstacle type")
            };
        }

        // Create Bat Speed randomly
        private static float CreateRandomBatSpeed(float gameSpeed)
        {
            return (float)(_random.NextDouble() * (0.25 * gameSpeed) + gameSpeed);
        }

        // Create Bat Y randomly
        private static float CreateRandomBatY()
        {
            if (_random.NextDouble() < 0.5)
            {
                return 348;
            }
            else
            {
                return 465;
            }
        }
    }
}