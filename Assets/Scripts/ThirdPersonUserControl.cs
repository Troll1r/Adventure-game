using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    //a[RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; 
        private Transform m_Cam;                  
        private Vector3 m_CamForward;             
        private Vector3 m_Move;
        private bool m_Jump;
        int hp;
        [SerializeField] Player player;
        bool isAlive = true;

        private void Start()
        {
            hp = player.hp;
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);

            }


            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (hp == 0)
                isAlive = false;
        }


        
        private void FixedUpdate()
        {
            if (isAlive)
            {
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                bool crouch = Input.GetKey(KeyCode.LeftControl);


                if (m_Cam != null)
                {

                    m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                    m_Move = v * m_CamForward + h * m_Cam.right;
                }
                else
                {

                    m_Move = v * Vector3.forward + h * Vector3.right;
                }
#if !MOBILE_INPUT

                if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif


                m_Character.Move(m_Move, crouch, m_Jump);
                m_Jump = false;

            }
        }
    }
}
