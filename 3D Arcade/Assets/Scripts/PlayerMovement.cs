
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace SAE
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform playerModel;
        
        public int xp = 0;
        public int level = 1;
        public int xpForNextLevel = 10;
        //private PlayerHealth health;

        public bool Joystick = true;

        public float moveSpeed = 18f;
        public float lookSpeed = 30f;
        public float forwardSpeed = 6f;

        public Transform aimTarget;
        //public Transform cameraParent;
        public Camera mainCamera;
        public CinemachineDollyCart dolly;

        public ParticleSystem flame;

        public GameObject bulletPrefab;
        public Transform firePoint;
        public RectTransform crosshairTexture;

        public float fireRate = 0.5F;
        public float nextFire = 0.0F;

        [HideInInspector]
        public bool canShoot = true;

        // Start is called before the first frame update
        void Start()
        {
            playerModel = gameObject.transform;
            //health = this.GetComponent<PlayerHealth>();
            SetXpForNextLevel();

            //SetSpeed(forwardSpeed);
            flame.Play();
        }

        // Update is called once per frame
        public void AxisUpdate(Vector2 axis)
        {
            Vector2 axisValues = axis;//ArcadeMachine.PlayerJoystickAxisStatic(ArcadeMachine.PlayerColorId.YELLOW_PLAYER);
            print(axis);
            float h = axisValues.x;
            float v = axisValues.y;

            //Shoot Function
            if ((Input.GetMouseButton(0) || SAE.ArcadeMachine.PlayerPressingButtonStatic(ArcadeMachine.PlayerColorId.YELLOW_PLAYER, 0) == true ) && (Time.time > nextFire) && canShoot)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }

            

            if (xp >= xpForNextLevel)
            {
                LevelUp();
                //health.RegenHealthFull();
            }

            LocalMove(h, v, moveSpeed);
            RotationLook(h, v, lookSpeed);
            HorizontalLean(playerModel, h, 45, .1f);

            if (crosshairTexture)
            {
                crosshairTexture.position = mainCamera.WorldToScreenPoint(transform.position + transform.forward * 100);
            }

        }

        void LocalMove(float x, float y, float speed)
        {
            transform.localPosition += new Vector3(x, -y, 0) * speed * Time.deltaTime;
            ClampPosition();
        }

        void ClampPosition()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            //transform.position = mainCamera.GetComponent<Camera>().ViewportToWorldPoint(pos);
        }

        void RotationLook(float h, float v, float speed)
        {
            aimTarget.parent.position = Vector2.zero;
            aimTarget.transform.position = new Vector3(h, -v, 1.8f);
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

        void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().shooter = this.gameObject;
            //SoundManager.instance.PlayShootFX(shootClip);

        }

        public void GainXP(int xpToGain)
        {
            xp += xpToGain;
            Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
        }

        void SetXpForNextLevel()
        {
            xpForNextLevel = (9 + (level * level * 1));
            Debug.Log("xpForNextLevel " + xpForNextLevel);
        }
        void LevelUp()
        {
            xp = 0;
            level++;

            //ScoreManager.levelValue += level;

            Debug.Log("level" + level);
            SetXpForNextLevel();
        }

    }    


      
}
