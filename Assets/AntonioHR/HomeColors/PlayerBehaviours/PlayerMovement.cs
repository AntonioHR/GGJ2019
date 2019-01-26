﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.HomeColors.PlayerBehaviours
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController charController;
        [SerializeField]
        private PlayerBody body;

        [SerializeField]
        private float speed = 5;
        float fixatedY;

        void Awake()
        {
            charController = GetComponent<CharacterController>();
        }

        public void Prepare(Player player)
        {
        }

        private void Start()
        {
            fixatedY = transform.position.y;
        }

        public void OnGameStarted()
        {
            Debug.Log("Player - On Game Started");
        }

        void Update()
        {
            var move = InputAsMoveAxis;
            body.IsMoving = move.sqrMagnitude > 0;
            body.MoveDirection = move;
            charController.Move(move * speed * Time.deltaTime);
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
        
    }
}