using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public class VSUIObject : MonoBehaviour
    {
        [ShowInInspector]
        public int ID { get; protected set; }

        public UnityEvent OnOpenStart { get; protected set; } = new();
        public UnityEvent OnOpenFinish { get; protected set; } = new();
        public UnityEvent OnCloseStart { get; protected set; } = new();
        public UnityEvent OnCloseFinish { get; protected set; } = new();

        public virtual void Open()
        {

        }
        public virtual void Close() 
        {

        }

        protected Tween OpenAnimation() { return null; }
        protected Tween CloseAnimation() { return null; }
    }
}

