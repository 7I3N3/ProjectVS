using UnityEngine;

namespace ProjectVS
{
    public class VSGameObject : MonoBehaviour
    {
        [field: SerializeField]
        public int ID { get; protected set; }

        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void Update() { }

        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
    }
}
