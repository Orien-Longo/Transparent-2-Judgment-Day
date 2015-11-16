using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 5f;
        public GameObject player1, player2, player3, lich;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;


        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
            //player1 = GameObject.FindGameObjectWithTag("Player1");
            //player2 = GameObject.FindGameObjectWithTag("Player2");
            //player3 = GameObject.FindGameObjectWithTag("Player3");
            //lich = GameObject.FindGameObjectWithTag("Lich");

        }


        public void LookRotation(Transform character, Transform camera)
        {
            float yRot = 0f;
            float xRot = 0f;

            if (character.CompareTag("Player1"))
            {
                character = player1.transform;
                Camera camera1 = GameObject.FindGameObjectWithTag("p1c").GetComponent<Camera>();
                camera = camera1.transform;
                yRot = CrossPlatformInputManager.GetAxis("P1Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("P1Mouse Y") * YSensitivity;
            }
            if (character.CompareTag("Player2"))
            {
                character = player2.transform;
                Camera camera2 = GameObject.FindGameObjectWithTag("p2c").GetComponent<Camera>();
                camera = camera2.transform;
                yRot = CrossPlatformInputManager.GetAxis("P2Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("P2Mouse Y") * YSensitivity;
            }
            if (character.CompareTag("Player3"))
            {
                character = player3.transform;
                Camera camera3 = GameObject.FindGameObjectWithTag("p3c").GetComponent<Camera>();
                camera = camera3.transform;
                yRot = CrossPlatformInputManager.GetAxis("P3Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("P3Mouse Y") * YSensitivity;
            }
            if (character.CompareTag("Lich"))
            {
                //character = lich.transform;
                //camera = lich.GetComponent<Camera>().transform;

                yRot = CrossPlatformInputManager.GetAxis("P4Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("P4Mouse Y") * YSensitivity;
                yRot = CrossPlatformInputManager.GetAxis("LichMouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("LichMouse Y") * YSensitivity;
            }

            m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

            if(clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

            if(smooth)
            {
                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
                    smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }
        }


        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }

    [Serializable]
    public class MouseLook2
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 5f;
        public GameObject player1, player2, player3, lich;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;


        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
            //player1 = GameObject.FindGameObjectWithTag("Player1");
            //player2 = GameObject.FindGameObjectWithTag("Player2");
            //player3 = GameObject.FindGameObjectWithTag("Player3");
            //lich = GameObject.FindGameObjectWithTag("Lich");
        }


        public void LookRotation(Transform character, Transform camera)
        {
            float yRot = 0f;
            float xRot = 0f;

            if (camera.CompareTag("Player1"))
            {
                character = player1.transform;
                camera = player1.GetComponent<Camera>().transform;
                yRot = CrossPlatformInputManager.GetAxis("P1Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("P1Mouse Y") * YSensitivity;
            }
            if (character.CompareTag("Player2"))
            {
                //character = player2.transform;
                //camera = player2.GetComponent<Camera>().transform;
                yRot = CrossPlatformInputManager.GetAxis("P2Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("P2Mouse Y") * YSensitivity;
            }
            if (character.CompareTag("Player3"))
            {
                //character = player3.transform;
                //camera = player3.GetComponent<Camera>().transform;
                yRot = CrossPlatformInputManager.GetAxis("P3Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("P3Mouse Y") * YSensitivity;
            }
            if (camera.CompareTag("Lich"))
            {
                //character = lich.transform;
                //camera = lich.GetComponent<Camera>().transform;

                //yRot = CrossPlatformInputManager.GetAxis("P4Mouse X") * XSensitivity;
                //xRot = CrossPlatformInputManager.GetAxis("P4Mouse Y") * YSensitivity;
                yRot = CrossPlatformInputManager.GetAxis("LichMouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("LichMouse Y") * YSensitivity;
            }

            m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            if (clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

            if (smooth)
            {
                character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
                    smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }
        }


        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
