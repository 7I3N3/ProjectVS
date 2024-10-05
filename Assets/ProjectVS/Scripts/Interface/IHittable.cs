using UnityEngine;
using UnityEngine.Events;
namespace ProjectVS
{
    public interface IHittable
    {
        public float MaxHP { get; }
        public float HP { get; }

        public float Shield { get; }

        public int Armor { get; }

        public UnityEvent<IDamageable> HitStartedEvent { get; }
        public UnityEvent<IDamageable> HitFinishedEvent { get; }
        public UnityEvent<IDamageable> DeadStartedEvent { get; }
        public UnityEvent<IDamageable> DeadFinishedEvent { get; }

        public void OnHit(IDamageable damager);
        public void OnDead(IDamageable damager);
    }
}