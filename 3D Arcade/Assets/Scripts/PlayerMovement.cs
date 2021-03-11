
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

        private int leanLimit;
        private float lerpTime;
        private object targetEulerAngels;
        public ParticleSystem flame;


        // Start is called before the first frame update
        void Start()
        {
            playerModel = transform.GetChild(0);

            flame.Play();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 axisValues = ArcadeMachine.PlayerJoystickAxisStatic(ArcadeMachine.PlayerColorId.YELLOW_PLAYER);
            float horizontal = axisValues.x;
            float vertical = axisValues.y;



            LocalMove(horizontal, vertical, moveSpeed);
            RotationLook(horizontal, vertical, lookSpeed);
            HorizontalLean(playerModel, horizontal, 80, .1f);

        }

        void LocalMove(float x, float y, float speed)
        {
            transform.localPosition += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
            ClampPosition();
        }

        void ClampPosition()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        void RotationLook(float horizontal, float vertical, float speed)
        {
            aimTarget.parent.position = Vector3.zero;
            aimTarget.localPosition = new Vector3(horizontal, vertical, 1);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed);
        }

        void HorizontalLean(Transform target, float axis, float leanLimt, float lerpTime)
        {
            Vector3 targetEulerAngles = target.localEulerAngles;
            target.localEulerAngles = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis * leanLimit, lerpTime));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(aimTarget.position, .5f);
            Gizmos.DrawSphere(aimTarget.position, .15f);
        }

    }    


      
}
