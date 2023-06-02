using Zenject;

namespace Modules.FlappyBirdModule.Scripts.Camera
{
    public class PlayerCamera : CameraFollower
    {
        private Character.Character character;
        
        public void SetupCharacter(Character.Character character)
        {
            this.character = character;
            followTarget = this.character.transform;
        }
    }
}