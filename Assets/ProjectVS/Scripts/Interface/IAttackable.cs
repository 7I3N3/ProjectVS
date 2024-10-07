using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IAttackable
    {
        public IDamageable Weapon { get; }
        public float AttackInterval { get; }

        public UnityEvent<Vector3> AttackStartedEvent { get; }
        public UnityEvent<Vector3> AttackFinishedEvent { get; }

        public void Attack(Vector3 target);
    }
}