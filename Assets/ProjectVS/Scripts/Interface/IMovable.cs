using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IMovable
    {
        public float Speed { get; }
        public Vector3 MoveVector { get; }

        public bool IsMoving { get; }

        public UnityEvent<Vector3> MoveStartedEvent { get; }
        public UnityEvent<Vector3> MoveFinishedEvent { get; }

        public void OnMove(Vector3 target);
    }
}

