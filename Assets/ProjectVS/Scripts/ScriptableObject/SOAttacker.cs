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
        public float Speed { get; protected set; } // ���Ÿ�: �Ѿ��� �ӵ�, �ٰŸ�: ȸ�� �ӵ� �Ǵ� ��ô �ӵ�
        [field: SerializeField]
        public float Range { get; protected set; } // ��Ÿ�
        [field: SerializeField]
        public float Delay { get; protected set; } // ���� �߻������ �ð�

        [field: SerializeField]
        public int MaxTargetCount { get; protected set; } 

        [field: SerializeField]
        public float IntervalTime { get; protected set; } // ������ �����ð�
    }
}

