using System;
using Modules.MainModule.Scripts;
using Modules.MainModule.Scripts.InputServices;
using UnityEngine;
using Zenject;

namespace Modules.FlappyBirdModule.Scripts.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float jumpForce;
        
        private Vector3 lastVelocity;

       
        private InputService inputService;
        public void SetupInputService(InputService inputService)
        {
            this.inputService = inputService;

            this.inputService.OnTap += Jump;
        }

        private void FixedUpdate()
        {
            var targetVelocity =
                Vector3.up * 
                (GameSettings.GRAVITY 
                 * GameSettings.GRAVITY_SCALE 
                 * GameSettings.TIME_SCALE
                 );

            if (GameSettings.IS_PAUSED)
            {
                targetVelocity = -rigidbody.velocity;
            }
            
            
            rigidbody.AddForce(targetVelocity);
        }

        private void Jump()
        {
            if (GameSettings.IS_PAUSED) return;
            
            var force = Vector2.up * jumpForce;
            force.y += -rigidbody.velocity.y;
            rigidbody.AddForce(force, ForceMode.Impulse);
            
        }

        private void OnDestroy()
        {
            inputService.OnTap -= Jump;
        }
    }
}