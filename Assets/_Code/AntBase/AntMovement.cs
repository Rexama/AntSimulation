using System;
using DG.Tweening;
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
        private Vector2 _obstacleRotateDirection;
        
        private bool _isRotating = false;
        private bool _isMoving = true;
        
        private void Awake()
        {
            _randomForward = (UnityEngine.Random.insideUnitSphere.normalized).normalized;
            transform.right = _randomForward;
            _randomForward = (UnityEngine.Random.insideUnitSphere.normalized).normalized;
        }
        
        private void FixedUpdate()
        {
            RandomWalk();
        }

        
        private void RandomWalk()
        {
            // if (_isRotating)
            // {
            //     Debug.DrawRay(transform.position, _randomForward, Color.red);
            //     var right = transform.right;
            //     var differenceX = Math.Abs(right.normalized.x - _randomForward.normalized.x);
            //     var differenceY = Math.Abs(right.normalized.y - _randomForward.normalized.y);
            //
            //     if (differenceX < 0.02f && differenceY < 0.02f)
            //     {
            //         _isRotating = false;
            //         _isMoving = true;
            //     }
            //     else
            //     {
            //         Debug.Log(transform.right+" "+_randomForward);
            //         transform.right = Vector2.Lerp(transform.right, _randomForward, rotationSpeed);
            //     }
            // }
            // else
            // {
            //     _randomForward = (UnityEngine.Random.insideUnitSphere.normalized).normalized;
            //     _isRotating = true;
            // }
            //
            // if(_isMoving)
            // {
            //     var newPos = transform.position + transform.right * speed;
            //     transform.position = newPos;
            // }
            
            
            if(!_isRotating)
            {
                _isRotating = true;
                
                var angle = new Vector3(0,0,Vector2.SignedAngle(transform.right, _randomForward));
                
                transform.DORotate(new Vector3(angle.x, angle.y, angle.z), rotationSpeed).SetSpeedBased().SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    _isRotating = false;
                    _isMoving = true;
                    _randomForward = (UnityEngine.Random.insideUnitSphere.normalized).normalized;
                    Debug.Log("Rotation complete");
                });
            }
            else
            {
                
            }
            
            if(_isMoving)
            {
                var newPos = transform.position + transform.right * speed;
                transform.position = newPos;
            }
        }
        

        public void OnObstacleDetected()
        {
            // DOTween.Kill(transform);
            // _isRotating = false;
            // _isMoving = false;
            // _randomForward = -transform.right;
            // Debug.Log("Obstacle detected");
            
        }
    }
}