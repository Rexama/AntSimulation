using System;
using UnityEngine;

namespace AntBase
{
    public class AntAntenna :MonoBehaviour
    {
        [SerializeField] private AntMovement antMovement;
        [SerializeField] private Collider2D collider;
        
        // private void OnTriggerEnter2D(Collider2D col)
        // {
        //     antMovement.OnAntennaTriggerEnter();
        // }
        //
        // public bool IsTouchingLayers()
        // {
        //     return collider.IsTouchingLayers();
        // }   
    }
}