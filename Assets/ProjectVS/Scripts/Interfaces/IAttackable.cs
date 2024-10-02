using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IAttackable
    {
        public SOAttacker AttackerData { get; }

        public UnityEvent<IDefensible[]> OnAttackStart { get; }
        public UnityEvent<IDefensible[]> OnAttackFinish { get; }

        public void Attack(IDefensible[] defenders);
    }
}

