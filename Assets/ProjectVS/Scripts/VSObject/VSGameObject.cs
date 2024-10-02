using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectVS
{
    public class VSGameObject : MonoBehaviour
    {
        [ShowInInspector]
        public int ID { get; protected set; }

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }
    }
}

