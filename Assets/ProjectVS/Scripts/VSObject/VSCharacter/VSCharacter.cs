using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public class VSCharacter : VSGameObject, IAttackable, IDefensible
    {
        [field: SerializeField]
        public SOAttacker AttackerData { get; protected set; }
        public UnityEvent<IDefensible[]> OnAttackStart { get; protected set; } = new();
        public UnityEvent<IDefensible[]> OnAttackFinish { get; protected set; } = new();

        [field: SerializeField]
        public SODefender DefenderData { get; protected set; }
        public bool IsDead { get; }
        public UnityEvent<IAttackable> OnHitStart { get; protected set; } = new();
        public UnityEvent<IAttackable> OnHitFinish { get; protected set; } = new();
        public UnityEvent<IAttackable> OnDeadStart { get; protected set; } = new();
        public UnityEvent<IAttackable> OnDeadFinish { get; protected set; } = new();

        protected Rigidbody rigid;
        protected Animator animator;

        protected override void Awake()
        {
            base.Awake();
            rigid = GetComponent<Rigidbody>();
            animator = GetComponentInChildren<Animator>();
        }

        public void Attack(IDefensible[] defenders)
        {
            OnAttackStart?.Invoke(defenders);

            OnAttack(defenders);

            OnAttackFinish?.Invoke(defenders);
        }
        protected virtual void OnAttack(IDefensible[] defenders)
        {

        }

        public void Hit(IAttackable attacker)
        {
            OnHitStart?.Invoke(attacker);

            OnHit(attacker);

            OnHitFinish?.Invoke(attacker);
        }
        protected virtual void OnHit(IAttackable attacker)
        {

        }
        public void Dead(IAttackable attacker)
        {
            OnDeadStart?.Invoke(attacker);

            OnDead(attacker);

            OnDeadFinish?.Invoke(attacker);
        }
        protected virtual void OnDead(IAttackable attacker)
        {

        }
    }
}

