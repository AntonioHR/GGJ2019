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
        private float speed = 5;
        
        void Awake()
        {
            charController = GetComponent<CharacterController>();
        }
        
        void Update()
        {
            charController.Move(InputAsMoveAxis * speed);
        }

        public Vector3 InputAsMoveAxis
        {
            get
            {
                var rotation = Quaternion.AngleAxis(45, Vector3.up);
                Vector3 vecBeforeRot = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
                vecBeforeRot.Normalize();
                return rotation * vecBeforeRot;
            }
        }
    }
}