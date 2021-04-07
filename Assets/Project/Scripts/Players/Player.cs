﻿using System;
using Scripts.Track;
using UnityEngine;

namespace Scripts.Players
{
    public abstract class Player : MonoBehaviour
    {
        public Action<float> OnMoved { get; set; }
        public float HorizontalMovement { get; set; }

        [SerializeField] private float speed;

        protected void Update()
        {
            var forwardVelocity = TrackParameters.Instance.forwardMovementDirection * (speed * Time.deltaTime);
            var horizontalVelocity = TrackParameters.Instance.horizontalMovementDirection * HorizontalMovement;

            var horizontalPosition = Vector3.ClampMagnitude(transform.position + horizontalVelocity,
                TrackParameters.Instance.trackWidth / 2f);
            
            Move(forwardVelocity + horizontalPosition - transform.position);
            transform.position = horizontalPosition;
            
            OnMoved?.Invoke(speed * Time.deltaTime);
        }

        protected abstract void Move(Vector3 velocity);
    }
}