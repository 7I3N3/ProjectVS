using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectVS
{
    public class VSHero : VSCharacter
    {
        protected Vector3 moveVec;
        protected Vector3 dodgeVec;

        protected Ray mouseRay;
        protected RaycastHit mouseHit;
        protected Vector3 mouseVec;
        protected Vector3 lookDir;

        [field: SerializeField]
        public float Speed { get; protected set; }
        public float CurrentSpeed 
        { 
            get 
            {
                float currentSpeed = 0;

                if (IsWalk)
                {
                    currentSpeed = Speed;

                    if (IsSprint)
                    {
                        currentSpeed *= SprintMulty;
                    }

                    if (IsDodge)
                    {
                        currentSpeed = Speed * 1.5f;
                    }
                }

                return currentSpeed;
            }
        }
        public float MaxSpeed { get { return Speed * SprintMulty; } }

        [field: SerializeField]
        public float SprintMulty { get; protected set; }

        public bool IsWalk { get { return moveVec != Vector3.zero; } }
        public bool IsSprint { get; protected set; } = false;
        public bool IsDodge { get; protected set; } = false;

        protected override void Awake()
        {
            base.Awake();
        }

        protected virtual void FixedUpdate()
        {
            rigid.MovePosition(transform.position + (IsDodge ? dodgeVec : moveVec) * CurrentSpeed * Time.deltaTime);
            transform.LookAt(transform.position + (IsDodge ? dodgeVec : moveVec));

            animator.SetFloat("Speed", CurrentSpeed / MaxSpeed);
            //transform.position += moveVec * Speed * Time.deltaTime;
        }
        
        #region Input
        protected virtual void OnMove(InputValue value)
        {
            Vector2 input = value.Get<Vector2>();

            moveVec = new Vector3(input.x, 0f, input.y);
        }

        protected virtual void OnLook(InputValue value)
        {
            Vector2 input = value.Get<Vector2>();

            mouseRay = Camera.main.ScreenPointToRay(input);

            if (Physics.Raycast(mouseRay, out mouseHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                mouseVec = mouseHit.point;
                lookDir = (mouseVec - transform.position).normalized;
                float distance = Mathf.Min(Vector3.Distance(mouseVec, transform.position), 5);
                //float distance = Mathf.Min(Vector3.Distance(mouseVec, transform.position), AttackerData.Range);

                mouseHit.point = transform.position + lookDir * distance;
            }
        }

        protected virtual void OnAttack(InputValue value)
        {

        }

        protected virtual void OnInteract(InputValue value)
        {

        }

        protected virtual void OnCrouch(InputValue value)
        {

        }

        protected virtual void OnJump(InputValue value)
        {
            if (value.isPressed && !IsDodge)
            {
                animator.SetTrigger("Dodge");
                IsDodge = true;
                dodgeVec = moveVec;

                Invoke("DodgeFinish", 0.8f);
            }
        }
        protected virtual void DodgeFinish()
        {
            IsDodge = false;
        }

        protected virtual void OnSprint(InputValue value)
        {
            if (value.isPressed)
            {
                IsSprint = true;
            }
            else
            {
                IsSprint = false;
            }
        }
        #endregion Input
    }
}
