using UnityEngine;

namespace Modules.FlappyBirdModule.Scripts.Camera
{
    public class CameraFollower : Follower
    {
        [SerializeField] protected Transform cameraTransform;

        private void Start()
        {
            cameraTransform.localPosition = offset;
        }

        protected void FixedUpdate()
        {
            Follow(Time.fixedDeltaTime);
        }
    }
}
