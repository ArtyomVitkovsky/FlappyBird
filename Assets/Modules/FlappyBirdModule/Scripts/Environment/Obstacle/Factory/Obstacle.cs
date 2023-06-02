using System;
using Modules.MainModule.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.FlappyBirdModule.Scripts.Environment.Obstacle.Factory
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private Transform upperPart;
        [SerializeField] private Transform bottomPart;
        [SerializeField] private Transform obstaclePassedTrigger;
        [SerializeField] private Rigidbody rigidbody;

        public bool isActive;
        
        private float speed;
        
        public UnityAction<Obstacle> OnObstacleReset;

        private Vector3 lastVelocity;

        private void FixedUpdate()
        {
            Move();
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
        
        public void SetHoleSize(float holeSize)
        {
            upperPart.localPosition = new Vector3(0, holeSize / 2f, 0);
            bottomPart.localPosition = new Vector3(0, -holeSize / 2f, 0);
        }

        public void SetWidth(float width)
        {
            transform.localScale = new Vector3(width, 1, width);
            obstaclePassedTrigger.transform.localPosition = new Vector3(0, 0, width / 2f);
        }

        public void Move()
        {
            if(!isActive) return;

            var targetVelocity = -Vector3.forward * (speed * GameSettings.TIME_SCALE);
            if(targetVelocity == lastVelocity) return;
            if (GameSettings.IS_PAUSED)
            {
                targetVelocity = -rigidbody.velocity;
            }

            lastVelocity = targetVelocity;
            rigidbody.AddForce(targetVelocity, ForceMode.VelocityChange);
        }
        
        public void Stop()
        {
            if(!isActive) return;

            lastVelocity = -rigidbody.velocity;
            rigidbody.AddForce(-rigidbody.velocity, ForceMode.VelocityChange);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ObstacleResetter"))
            {
                Stop();
                isActive = false;
                
                OnObstacleReset?.Invoke(this);
            }
        }
    }
}