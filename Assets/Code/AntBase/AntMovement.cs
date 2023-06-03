using System;
using UnityEngine;

namespace AntBase
{
    public class AntMovement : MonoBehaviour
    {
        public float speed = 2;
        public float rotationSpeed = 2;
        public float wanderWeight = 5;


        private Vector2 position;
        private Vector2 velocity;
        private Vector2 randomForward;
        
        private bool isRotating = false;

        private void FixedUpdate()
        {
            // var desiredForward = (forward + (Vector2) UnityEngine.Random.insideUnitSphere.normalized * wanderWeight).normalized;
            //
            //
            // forward = Vector2.Lerp(forward, desiredForward, rotationSpeed);
            // Debug.DrawRay(transform.position, forward, Color.red);
            //
            // velocity = forward * speed;
            // position += velocity;

            if (isRotating)
            {
                //.Log((Vector2)transform.right.normalized + " " + randomForward.normalized);
                
                var differenceX = Math.Abs(transform.right.normalized.x - randomForward.normalized.x);
                var differenceY = Math.Abs(transform.right.normalized.y - randomForward.normalized.y);
                if(differenceX < 0.02f && differenceY < 0.02f)
                {
                    Debug.Log(differenceX + " " + differenceY);
                    Debug.Log((Vector2)transform.right.normalized + " " + randomForward.normalized);
                    isRotating = false;
                }
                else
                {
                    transform.right = Vector2.Lerp(transform.right, randomForward, rotationSpeed);
                }
            }
            else
            {
                randomForward = (UnityEngine.Random.insideUnitSphere.normalized * wanderWeight).normalized;
                isRotating = true;
            }
            
            var newPos = transform.position + (Vector3)transform.right * speed;
            transform.position = newPos;
        }
    }
}