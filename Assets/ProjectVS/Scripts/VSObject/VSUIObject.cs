using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectVS
{
    public class VSUIObject : MonoBehaviour
    {
        [field: SerializeField]
        public int ID { get; protected set; }

        public bool IsOpened { get; protected set; }

        public UnityEvent OpenStartedEvent { get; protected set; } = new();
        public UnityEvent OpenFinishedEvent { get; protected set; } = new();
        public UnityEvent CloseStartedEvent { get; protected set; } = new();
        public UnityEvent CloseFinishedEvent { get; protected set; } = new();

        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void Update() { }

        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }

        public virtual void Open()
        {
            OpenStartedEvent?.Invoke();
            if (OpenAnimation() != null)
            {
                OpenAnimation().OnComplete(OnOpenFinished);
            }
            else
            {
                OnOpenFinished();
            }
        }
        public virtual void Close()
        {
            CloseStartedEvent?.Invoke();
            if (CloseAnimation() != null)
            {
                CloseAnimation().OnComplete(OnCloseFinished);
            }
            else
            {
                OnCloseFinished();
            }
        }

        protected virtual void OnOpenFinished()
        {
            OpenFinishedEvent?.Invoke();
        }
        protected virtual void OnCloseFinished()
        {
            CloseFinishedEvent?.Invoke();
        }

        protected virtual Tween OpenAnimation() { return null; }
        protected virtual Tween CloseAnimation() { return null; }
    }
}