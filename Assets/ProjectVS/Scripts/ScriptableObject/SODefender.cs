using System;
using UnityEngine;

namespace ProjectVS
{
    [CreateAssetMenu(fileName = "SODeffender", menuName = "Scriptable Objects/SODefender")]
    public class SODefender : ScriptableObject
    {
        [field: SerializeField]
        public float MaxHP { get; protected set; }
        [field: SerializeField]
        public float HP { get; protected set; }

        [field: SerializeField]
        public float MeleeDef { get; protected set; }
        [field: SerializeField]
        public float MagicDef { get; protected set; }
    }
}

