using System;
using DG.Tweening;
using UnityEngine;

namespace AntBase
{
    public class AntMovement : MonoBehaviour
    {
        public AntSettings antSettings;

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
            if(!_isRotating)
            {
                _isRotating = true;
                
                var angle = new Vector3(0,0,Vector2.SignedAngle(transform.right, _randomForward));
                
                transform.DORotate(new Vector3(angle.x, angle.y, angle.z), antSettings.rotationSpeed).SetSpeedBased().SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    _isRotating = false;
                    _isMoving = true;
                    _randomForward = (UnityEngine.Random.insideUnitSphere.normalized).normalized;
                });
            }

            if(_isMoving)
            {
                var newPos = transform.position + transform.right * antSettings.speed;
                transform.position = newPos;
            }
        }
        

        public void OnObstacleDetected()
        {
            DOTween.Kill(transform);
            _isRotating = false;
            _isMoving = false;
            _randomForward = -transform.right;
        }
    }
}