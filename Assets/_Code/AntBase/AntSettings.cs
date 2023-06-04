using UnityEngine;

namespace AntBase
{
    [CreateAssetMenu(fileName = "AntSettings", menuName = "AntSettings", order = 0)]
    public class AntSettings : ScriptableObject
    {
        [Header("Movement")]
        public float speed = 2;
        public float rotationSpeed = 2;
        
        
    }
}