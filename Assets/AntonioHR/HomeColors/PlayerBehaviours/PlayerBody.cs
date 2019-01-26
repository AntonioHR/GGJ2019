using AntonioHR.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors.PlayerBehaviours
{
    [RequireComponent(typeof(Animator))]
    public class PlayerBody : MonoBehaviour, IProxyFor<Player>
    {
        private bool isMoving;
        private Vector3 moveDirection;
        private float rotateVelocity;
        private float rotateTime = .2f;
        private readonly Vector3 defaultDirection = Vector3.right;

        private Player owner;
        private Animator animator;

        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
            set
            {
                if (isMoving == value)
                    return;

                animator.SetBool("moving", value);
                isMoving = value;
            }
        }

        public Vector3 MoveDirection
        {
            get
            {
                return moveDirection;
            }
            set
            {
                if (value.sqrMagnitude == 0)
                    return;
                moveDirection = value;
            }
        }

        public Player Owner { get { return owner; } }



        public void Prepare(Player owner)
        {
            this.owner = owner;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            float angle = Vector3.SignedAngle(defaultDirection, moveDirection, Vector3.up);
            var euler = transform.eulerAngles;
            euler.y = Mathf.SmoothDampAngle(euler.y, angle, ref rotateVelocity, rotateTime);
            euler.y = angle;
            transform.eulerAngles = euler;
        }

        
    }
}
