using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class SliderScript : MonoBehaviour
    {
        public float speedDown = 5f, speedUp = -5;

        private SliderJoint2D _slider;
        private void Start()
        {
            _slider = GetComponent<SliderJoint2D>();
            StartCoroutine(setSpeedMotor());
        }

        private IEnumerator setSpeedMotor()
        {
            JointMotor2D jointMotor2D = new JointMotor2D();
            jointMotor2D.motorSpeed = _slider.motor.motorSpeed == speedDown ? speedUp : speedDown;
            jointMotor2D.maxMotorTorque = 10000f;
            _slider.motor = jointMotor2D;
            yield return new WaitForSeconds(5f);

            StartCoroutine(setSpeedMotor());
        }
    }
}
