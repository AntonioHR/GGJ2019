using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.HomeColors.PlayerBehaviours
{
    public class PlayerMovement : MonoBehaviour
    {
        private const float snapTime = .2f;

        private CharacterController charController;
        [SerializeField]
        private PlayerBody body;
        [SerializeField]
        private float speed = 5;

        private bool snapped = false;
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
            if (snapped)
            {
                body.IsMoving = false;
                body.MoveDirection = transform.forward;
                return;
            }

            var move = InputAsMoveAxis;
            body.IsMoving = move.sqrMagnitude > 0;
            body.MoveDirection = move;
            charController.Move(move * speed * Time.deltaTime);
        }

        public void MoveTo(Vector3 position)
        {
            charController.enabled = false;
            body.gameObject.SetActive(false);
            transform.DOMove(position, .2f).OnComplete(() =>
            {
                charController.enabled = true;
                body.gameObject.SetActive(true);
            });
        }

        public void SnapTo(Vector3 position, Quaternion rotation, Action callback)
        {
            charController.enabled = false;
            transform.DORotateQuaternion(rotation, snapTime);
            transform.DOMove(position, snapTime).OnComplete(() =>
            {
                callback();
                snapped = true;
            });
        }

        internal void Snap()
        {
            snapped = true;
            charController.enabled = false;
        }

        public void Unsnap()
        {
            snapped = false;
            charController.enabled = true;
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