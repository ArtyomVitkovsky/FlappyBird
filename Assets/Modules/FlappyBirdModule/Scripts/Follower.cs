using UnityEngine;

namespace Modules.FlappyBirdModule.Scripts
{
    public abstract class Follower : MonoBehaviour
    {
        [SerializeField] protected Transform followTarget;
        [SerializeField] protected float followSpeedX;
        [SerializeField] protected float followSpeedY;
        [SerializeField] protected float followSpeedZ;
        [SerializeField] protected Vector3 offset;

        [SerializeField] protected bool X;
        [SerializeField] protected bool Y;
        [SerializeField] protected bool Z;
        
        protected bool isActive;

        protected void Follow(float deltaTime)
        {
            if(followTarget == null) return;
            
            if(!X && !Y && !Z) return;

            Vector3 targetPosition = transform.position;
            
            if (X)
            {
                targetPosition.x = TargetPositionByAxis(
                    deltaTime, 
                    transform.position.x, 
                    followTarget.position.x, 
                    offset.x,
                    followSpeedX);
            }
            
            if (Y)
            {
                targetPosition.y = TargetPositionByAxis(
                    deltaTime, 
                    transform.position.y, 
                    followTarget.position.y, 
                    offset.y,
                    followSpeedY);
            }

            if (Z)
            {
                targetPosition.z = TargetPositionByAxis(
                    deltaTime, 
                    transform.position.z, 
                    followTarget.position.z, 
                    offset.z,
                    followSpeedZ);
            }

            
            transform.position = targetPosition;
        }

        private float TargetPositionByAxis(float deltaTime, float current, float target, float offset, float speed)
        {
            var distance = Mathf.Abs(current - (target + offset));

            var result = Mathf.Lerp(
                current,
                target + offset,
                deltaTime * speed * distance);
            
            return result;
        }

        public void SetFollowTarget(Transform followTarget)
        {
            this.followTarget = followTarget;
            isActive = this.followTarget != null;

        }
    }
}