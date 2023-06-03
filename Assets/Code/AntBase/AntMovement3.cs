// using System;
// using UnityEngine;
//
// namespace AntBase
// {
//     public class AntMovement : MonoBehaviour
//     {
//         [SerializeField] private AntAntenna _rightAntenna;
//         [SerializeField] private AntAntenna _leftAntenna;
//             
//         
//         public int speed = 2;
//         public int steerStrength = 2;
//         public int wanderStrength = 1;
//
//         private Vector2 _position;
//         private Vector2 _velocity;
//         private Vector2 _desiredDirection;
//         private bool _isTurning = false;
//         
//
//         private void Update()
//         {
//             if(_isTurning)
//             {
//                 HandleTurning();
//             }
//             else
//             {
//                 
//                 HandleMovement();
//             }
//         }
//
//         private void HandleTurning()
//         {
//             if (_isTurning)
//             {
//                 if (_rightAntenna.IsTouchingLayers())
//                 {
//                     
//                 }
//                 else
//                 {
//                     HandleMovement();
//                     _isTurning = false;
//                 }
//                 
//             }
//         }
//
//         private void HandleMovement()
//         { 
//             // Debug.Log("HandleMovement");
               //_desiredDirection = (_desiredDirection + (Vector2) UnityEngine.Random.insideUnitSphere * wanderStrength).normalized;
//             // var desiredVelocity = _desiredDirection * speed;
//             // var desiredSteeringForce = (desiredVelocity - _velocity).normalized * steerStrength;
//             // var acceleration = Vector2.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;
//             //
//             // _velocity = Vector2.ClampMagnitude(_velocity + acceleration * Time.deltaTime, speed);
//             // _position += _velocity * Time.deltaTime;
//             //
//             // float angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
//             // transform.SetPositionAndRotation(_position, Quaternion.AngleAxis(angle, Vector3.forward));
//             
//             
//         }
//
//         public void OnAntennaTriggerEnter()
//         {
//             Debug.Log("Collided  ");
//             _isTurning = true;
//         }
//     }
// }
