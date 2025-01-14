﻿using UnityEngine;

namespace TouchToStart
{
    public class Stick : Controller
    {
        [SerializeField] private GameObject joyStick;
        [SerializeField] private CircleCollider2D centerCollider;
        private Vector2 mousePosition;

        public float ActiveAreaRadius;

        protected override Vector2 CalculateOutput()            // 최종 속도벡터 출력
        {
            Vector2 velocity;
            Transform SameDepthMouseTransform = SameDepthMouse.gameObject.transform;
            
            velocity = SameDepthMouseTransform.position;
            velocity = velocity.normalized * Speed;

            joyStick.transform.position = 0.1f*SameDepthMouseTransform.position;

            if (!IsHovering()) {
                velocity = Vector2.zero;
            }

            return velocity;
        }

        protected override bool IsHovering()            //컨트롤 패드에 대해 samedepthmouse가 유효 영역 안에 들어왔는가?(ActiveAreaRadius보다 위치 벡터의 크기가 큰가?)
        {
            mousePosition = SameDepthMouse.transform.position;
            // Transform SameDepthMouseTransform = SameDepthMouse.gameObject.transform;
            // float Radius = SameDepthMouseTransform.position.magnitude;                        //samedepthmouse의 중심으로부터의 거리
            /*
            if(Radius > ActiveAreaRadius)
            {
                return true;
            }

            else
            {
                return false;
            }*/
            if (centerCollider.OverlapPoint(mousePosition))
            {
                joyStick.transform.position = Vector3.zero;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}