using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public class VSCharacter : VSGameObject, IHittable, IAttackable, IRotatable, IMovable
    {
        #region IHittable
        [field: SerializeField]
        public float MaxHP { get; protected set; }
        public float HP { get; protected set; }
        public float Shield { get; protected set; }
        [field: SerializeField]
        public int Armor { get; protected set; }

        public UnityEvent<IDamageable> HitStartedEvent { get; protected set; } = new();
        public UnityEvent<IDamageable> HitFinishedEvent { get; protected set; } = new();
        public UnityEvent<IDamageable> DeadStartedEvent { get; protected set; } = new();
        public UnityEvent<IDamageable> DeadFinishedEvent { get; protected set; } = new();

        public virtual void Dead(IDamageable damager)
        {

        }
        public virtual void Hit(IDamageable damager)
        {
            
        }
        #endregion IHittable

        #region IAttackable
        public IDamageable Weapon { get; protected set; }
        [field: SerializeField]
        public float AttackInterval { get; protected set; }
        
        public UnityEvent<Vector3> AttackStartedEvent { get; protected set; } = new();
        public UnityEvent<Vector3> AttackFinishedEvent { get; protected set; } = new();

        public virtual void Attack(Vector3 target)
        {

        }
        #endregion IAttackable

        #region IRotatable
        [field: SerializeField]
        public float RotateSpeed { get; protected set; }
        public Vector3 RotateDirection { get; protected set; }

        public UnityEvent<Vector3> RotateStartedEvent { get; protected set; } = new();
        public UnityEvent<Vector3> RotateFinishedEvent { get; protected set; } = new();

        public virtual void Rotate(Vector3 target)
        {
            transform.LookAt(transform.position + RotateDirection);
        }
        #endregion IRotatable

        #region IMovable
        [field: SerializeField]
        public float MovementSpeed { get; protected set; }

        public Vector3 MoveVector { get; protected set; }

        public bool IsMoving { get => MoveVector != Vector3.zero; }

        public UnityEvent<Vector3> MoveStartedEvent { get; protected set; } = new();

        public UnityEvent<Vector3> MoveFinishedEvent { get; protected set; } = new();

        public virtual void Move(Vector3 target)
        {
            rigid.MovePosition(transform.position + target);

            float angle = Mathf.Atan2(RotateDirection.normalized.z, RotateDirection.normalized.x) * Mathf.Rad2Deg - 90f;

            Vector3 velocity = Quaternion.AngleAxis(angle, Vector3.up) * MoveVector;

            animator.SetFloat("VelocityX", velocity.normalized.x);
            animator.SetFloat("VelocityZ", velocity.normalized.z);
        }
        #endregion IMovable

        #region Character
        protected Rigidbody rigid;
        protected Animator animator;

        protected override void Awake()
        {
            base.Awake();
            rigid = GetComponent<Rigidbody>();
            animator = GetComponentInChildren<Animator>();
        }
        #endregion Character
    }
}
