using System;
using UnityEngine;

namespace AntBase
{
    public class AntMovement : MonoBehaviour
    {
        public float speed = 2;
        public float rotationSpeed = 2;


        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _randomForward;
        
        private bool _isRotating = false;

        private void FixedUpdate()
        {
            RandomWalk();
        }

        private void RandomWalk()
        {
            if (_isRotating)
            {
                var right = transform.right;
                var differenceX = Math.Abs(right.normalized.x - _randomForward.normalized.x);
                var differenceY = Math.Abs(right.normalized.y - _randomForward.normalized.y);

                if (differenceX < 0.02f && differenceY < 0.02f)
                {
                    _isRotating = false;
                }
                else
                {
                    transform.right = Vector2.Lerp(transform.right, _randomForward, rotationSpeed);
                }
            }
            else
            {
                _randomForward = (UnityEngine.Random.insideUnitSphere.normalized).normalized;
                _isRotating = true;
            }

            var newPos = transform.position + transform.right * speed;
            transform.position = newPos;
        }
    }
}