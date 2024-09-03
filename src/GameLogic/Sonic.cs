using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SplashKitSDK;

namespace SoNeat.src.GameLogic
{
    public class Sonic : GameObject
    {
        public const string DEFAULT_FOLDER_PATH = "assets/images/Sonic";
        private bool _isJumping;
        private bool _isDucking;
        private float _velocityY;
        private float _floorY;
        private float _gravity;

        public Sonic(float x, float y, float floorY, float gameSpeed, string folderPath = DEFAULT_FOLDER_PATH)
                    : base(x, y, 0, gameSpeed, folderPath)
        {
            _isJumping = false;
            _isDucking = false;
            _velocityY = 0;
            _floorY = floorY;
            _gravity = 1f;
        }

        public override void Update()
        {
            Move();

            Sprite.Update();
        }

        public override void Move()
        {
            if (SplashKit.KeyTyped(KeyCode.DownKey))
            {
                Duck();
            }

            if (SplashKit.KeyUp(KeyCode.DownKey))
            {
                _isDucking = false;
            }

            if (SplashKit.KeyDown(KeyCode.SpaceKey))
            {
                Jump();
            }

            if (_isJumping)
            {
                Y -= _velocityY;
                _velocityY -= _gravity;
            }

            if (IsOnGround())
            {
                _velocityY = 0;
                _gravity = 0;
                _isJumping = false;
            }

            if (!_isJumping && !_isDucking && !SplashKit.KeyDown(KeyCode.SpaceKey))
            {
                Run();
            }

            if (IsOnGround())
                Y = _floorY - CurrentBitmap.Height;
        }

        public void Jump(bool isLongJump = true)
        {
            if (_isJumping)
                return;

            if (isLongJump)
            {
                _velocityY = 22;
                _gravity = 1.2f;
            }
            else
            {
                _velocityY = 18;
                _gravity = 1f;
            }
            _isJumping = true;

            if (_isDucking)
            {
                _isDucking = false;
            }

            Sprite.Play("Jump");
        }

        public void Duck()
        {
            if (_isDucking)
                return;

            _isDucking = true;
            _gravity = 5;

            Sprite.Play("Duck");
            if (!_isJumping)
                Y = _floorY - CurrentBitmap.Height;
        }

        public void Run()
        {
            Sprite.Play("Run");
        }

        public bool IsOnGround()
        {
            return Y >= _floorY - CurrentBitmap.Height;
        }
    }
}