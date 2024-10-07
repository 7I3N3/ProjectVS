using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ProjectVS
{
    public class VSHero : VSCharacter, IDodgeable
    {
        #region IDodgeable
        public Vector3 DodgeVector { get; protected set; }
        public bool IsDodging { get; protected set; }

        public UnityEvent DodgeStartedEvent { get; protected set; } = new();
        public UnityEvent DodgeFinishedEvent { get; protected set; } = new();

        public virtual void Dodge()
        {

            DodgeFinishedEvent?.Invoke();
            IsDodging = false;
        }
        #endregion

        protected virtual void FixedUpdate()
        {
            Move((IsDodging ? DodgeVector : MoveVector) * (IsDodging ? MovementSpeed * 2f : MovementSpeed) * Time.deltaTime);
            Rotate(RotateDirection);
        }

        #region Input
        protected virtual void OnMove(InputValue value)
        {
            Vector2 input = value.Get<Vector2>();

            MoveVector = new Vector3(input.x, 0f, input.y);

            if (MoveVector != Vector3.zero && !IsMoving)
            {
                MoveStartedEvent?.Invoke(MoveVector);
            }
            else
            {
                MoveFinishedEvent?.Invoke(MoveVector);
            }
        }
        protected virtual void OnDodge(InputValue value)
        {
            if (value.isPressed && !IsDodging)
            {
                IsDodging = true;
                DodgeVector = RotateDirection.normalized;
                animator.SetTrigger("Dodge");
                DodgeStartedEvent?.Invoke();

                Invoke("Dodge", 0.8f);
            }
            else
            {
                
            }
        }
        protected virtual void OnAttack(InputValue value)
        {
            if (value.isPressed)
            {
                AttackStartedEvent?.Invoke(RotateDirection);
            }
            else
            {
                AttackFinishedEvent?.Invoke(RotateDirection);
            }
        }
        protected virtual void OnLook(InputValue value)
        {
            Vector2 input = value.Get<Vector2>();

            Ray ray = Camera.main.ScreenPointToRay(input);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")) && !IsDodging)
            {
                RotateDirection = (hit.point - transform.position).normalized;
            }

            if (RotateDirection != Vector3.zero)
            {
                RotateStartedEvent?.Invoke(RotateDirection);
            }
            else
            {
                RotateFinishedEvent?.Invoke(RotateDirection);
            }
        }
        protected virtual void OnInteract(InputValue value)
        {
            if(value.isPressed)
            {

            }
            else
            {

            }
        }
        #endregion Input
    }
}
