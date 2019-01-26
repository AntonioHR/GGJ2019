using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.HomeColors.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController charController;
        [SerializeField]
        private PlayerBody body;

        [SerializeField]
        private float speed = 5;
        float fixatedY;
        private Vector3 move;

        void Awake()
        {
            charController = GetComponent<CharacterController>();
        }
        private void Start()
        {
            body.Setup(this);
            fixatedY = transform.position.y;
        }

        void Update()
        {
            move = InputAsMoveAxis;
            body.IsMoving = move.sqrMagnitude > 0;
            body.MoveDirection = move;
            charController.Move(move * speed);
        }

        private void LateUpdate()
        {
            var pos = transform.position;
            pos.y = fixatedY;
            transform.position = pos;
        }

        public Vector3 InputAsMoveAxis
        {
            get
            {
                var rotation = Quaternion.AngleAxis(45, Vector3.up);
                Vector3 vecBeforeRot = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
                if (vecBeforeRot.sqrMagnitude > 1)
                    vecBeforeRot.Normalize();
                return rotation * vecBeforeRot;
            }
        }

        public void Push(Vector3 delta)
        {
            charController.Move(delta);
        }
    }
}