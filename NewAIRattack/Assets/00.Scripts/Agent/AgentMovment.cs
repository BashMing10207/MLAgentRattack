using System;
using UnityEngine;


    public class AgentMovment : MonoBehaviour,IGetCompoable
    {
        public Action<Vector2> OnMovement;
        private Rigidbody _rbCompo;

        private float _moveSpeed = 3f;
        private Vector2 _movement;
        private Agent _agent;

        private float _speedMultiplier;

        public void SetSpeedMultiplier(float value) => _speedMultiplier = value;

        public void Initialize(GetCompoParent entity)
        {
            _agent = (Agent)entity;
            _rbCompo = entity.GetComponent<Rigidbody>();
        }

        //public void OnMove(Vector3 direction, float maxSpeed)
        //{
        //    OnMovement?.Invoke(_rbCompo.velocity);
        //    _rbCompo.AddForce(direction * Mathf.Lerp(1, 0, (Vector3.Project(direction, _rbCompo.velocity) + _rbCompo.velocity).magnitude / maxSpeed),ForceMode.Impulse);
        //}

        public void Move(Vector3 dir)
        {
           _rbCompo.AddForce(dir,ForceMode.Impulse);
        }

        private void OnDestroy()
        {
             
        }
    }
