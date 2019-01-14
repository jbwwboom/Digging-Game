using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);

            //PC
            float h = Input.GetAxis("Horizontal");

            //MOBILE
            /*float h = 0.0f;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                float diff = Math.Abs(player.transform.position.y - vec.y);

                if (diff <= 0.5)
                {
                    h = (touch.position.x > (Screen.width / 2)) ? 1 : -1;
                    h /= 3;
                }
                 
            }*/


            if (h!=0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PlayerWalk");
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PlayerStopWalk");
            }
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
