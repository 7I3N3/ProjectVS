using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public interface IDamageable
    {
        public float Damage { get; }
        public float FixedPenetration { get; }
        public float PercentPenetration { get; }
        public float Delay { get; }
        public float Interval { get; }
        public int TargetCount { get; }

        public UnityEvent<List<IHittable>> DamageStartedEvent { get; }
        public UnityEvent<List<IHittable>> DamageFinishedEvent { get; }

        public void OnDamage(List<IHittable> hitList);
    }
}

