using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IRotatable
    {
        public float RotateSpeed { get; }
        public Vector3 RotateDirection { get; }

        public UnityEvent<Vector3> RotateStartedEvent { get; }
        public UnityEvent<Vector3> RotateFinishedEvent { get; }

        public void Rotate(Vector3 target);
    }
}
