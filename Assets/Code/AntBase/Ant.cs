using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public int speed = 2;
    public int steerStrength = 2;
    public int wanderStrength = 1;

    private Vector2 _position;
    private Vector2 _velocity;
    private Vector2 _desiredDirection;
    
    private void Update()
    {
        // var randomPosition = UnityEngine.Random.insideUnitCircle * 0.5f;
        // var direction = new Vector3(randomPosition.x, randomPosition.y, randomPosition.y);
        // transform.position += direction * speed * Time.deltaTime;
        // transform.SetPositionAndRotation();
        
        
        
        _desiredDirection = (_desiredDirection + (Vector2)UnityEngine.Random.insideUnitSphere * wanderStrength).normalized;
        var desiredVelocity = _desiredDirection * speed;
        var desiredSteeringForce = (desiredVelocity - _velocity).normalized * steerStrength;
        var acceleration = Vector2.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;
        
        _velocity = Vector2.ClampMagnitude(_velocity + acceleration * Time.deltaTime, speed);
        _position += _velocity * Time.deltaTime;
        
        float angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(_position, Quaternion.AngleAxis(angle, Vector3.forward));
    }
}
