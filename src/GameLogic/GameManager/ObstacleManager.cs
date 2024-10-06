using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNeat.src.GameLogic
{
    public class ObstacleManager : GameManagerBase
    {
        public List<Obstacle> Obstacles => gameObjects.Cast<Obstacle>().ToList();

        public ObstacleManager(float gameSpeed)
            : base(gameSpeed, new ObstacleSpawnStrategy())
        {
            nextSpawnInterval = 50;
        }

        protected override bool ShouldSpawn()
        {
            return nextSpawnInterval > 111 - gameSpeed;
        }

        public void Update(Sonic sonic)
        {
            base.Update();

            if (IsColliding(sonic))
            {
                sonic.IsDead = true;
            }
        }

        public void Update(Population population)
        {
            base.Update();

            foreach (Sonic sonic in population.Data!)
            {
                if (!sonic.IsDead && IsColliding(sonic))
                {
                    sonic.IsDead = true;
                    population.Alives--;
                }
            }
        }

        private bool IsColliding(Sonic sonic)
        {
            return Obstacles.Any(obstacle => obstacle.IsColliding(sonic));
        }

        public void Reset()
        {
            gameObjects.Clear();
            nextSpawnInterval = 50;
        }
    }
}