using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.HomeColors
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController charController;
        [SerializeField]
        private PlayerBody body;

        [SerializeField]
        private float speed = 5;
        
        void Awake()
        {
            charController = GetComponent<CharacterController>();
        }
        
        void Update()
        {
            var move = InputAsMoveAxis;
            body.IsMoving = move.sqrMagnitude > 0;
            body.MoveDirection = move;
            charController.Move(move * speed);
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
    }
}