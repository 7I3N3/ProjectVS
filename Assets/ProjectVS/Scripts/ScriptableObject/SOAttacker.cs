using System;
using UnityEngine;

namespace ProjectVS
{
    public enum AttackType
    {
        NONE,
        MELEE,
        MAGIC,
        FIXED,

    }

    [CreateAssetMenu(fileName = "SOAttacker", menuName = "Scriptable Objects/SOAttacker")]
    public class SOAttacker : ScriptableObject
    {
        [field: SerializeField]
        public string WeaponName { get; protected set; }

        [field: SerializeField]
        public AttackType Type { get; protected set; }

        [field: SerializeField]
        public float Damage { get; protected set; }
        [field: SerializeField]
        public float Speed { get; protected set; } // 원거리: 총알의 속도, 근거리: 회전 속도 또는 투척 속도
        [field: SerializeField]
        public float Range { get; protected set; } // 사거리
        [field: SerializeField]
        public float Delay { get; protected set; } // 다음 발사까지의 시간

        [field: SerializeField]
        public int MaxTargetCount { get; protected set; } 

        [field: SerializeField]
        public float IntervalTime { get; protected set; } // 무기의 유지시간
    }
}

