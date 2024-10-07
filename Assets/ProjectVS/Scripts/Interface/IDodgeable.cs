using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IDodgeable : IMovable
    {
        public Vector3 DodgeVector { get; }
        public bool IsDodging { get; }

        public UnityEvent DodgeStartedEvent { get; }
        public UnityEvent DodgeFinishedEvent { get; }

        public void Dodge();
    }
}

