using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IDefensible
    {
        public SODefender DefenderData { get; }

        public bool IsDead { get; }

        public UnityEvent<IAttackable> OnHitStart { get; }
        public UnityEvent<IAttackable> OnHitFinish { get; }
        public UnityEvent<IAttackable> OnDeadStart { get; }
        public UnityEvent<IAttackable> OnDeadFinish { get; }

        public void Hit(IAttackable attacker);
        public void Dead(IAttackable attacker);
    }
}

