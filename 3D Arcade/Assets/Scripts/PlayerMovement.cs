
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace SAE
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform playerModel;

        public bool Joystick = true;

        public float moveSpeed = 18;
        public float lookSpeed = 340;
        public float forwardSpeed = 6;

        public Transform aimTarget;
        public Transform cameraParent;
        public CinemachineDollyCart dolly;

        public ParticleSystem flame;


        // Start is called before the first frame update
        void Start()
        {
            playerModel = transform.GetChild(0);

            SetSpeed(forwardSpeed);
            flame.Play();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 axisValues = ArcadeMachine.PlayerJoystickAxisStatic(ArcadeMachine.PlayerColorId.YELLOW_PLAYER);
            float h = axisValues.x;
            float v = axisValues.y;



            LocalMove(h, v, moveSpeed);
            RotationLook(h, v, lookSpeed);
            HorizontalLean(playerModel, h, 50, .1f);

        }

        void LocalMove(float x, float y, float speed)
        {
            transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
            ClampPosition();
        }

        void ClampPosition()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        void RotationLook(float h, float v, float speed)
        {
            aimTarget.parent.position = Vector2.zero;
            aimTarget.transform.position = new Vector3(h, v, 1);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed);
        }

        void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
        {
            Vector3 targetEulerAngels = target.localEulerAngles;
            target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(aimTarget.position, .5f);
            Gizmos.DrawSphere(aimTarget.position, .15f);
        }

        void SetSpeed(float x)
        {
            dolly.m_Speed = x;
        }

    }    


      
}
