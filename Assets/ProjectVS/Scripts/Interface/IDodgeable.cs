using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IDodgeable : IMovable
    {
        public bool IsDodging { get; }

        public UnityEvent DodgeStartedEvent { get; }
        public UnityEvent DodgeFinishedEvent { get; }

        public void OnDodge();
    }
}

