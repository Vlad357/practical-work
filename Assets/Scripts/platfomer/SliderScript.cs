using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class SliderScript : MonoBehaviour
    {
        public float speedDown = 5f, speedUp = -5;
        public float timeWait = 5f;

        private SliderJoint2D _slider;

        private void Start()
        {
            _slider = GetComponent<SliderJoint2D>();
            StartCoroutine(SetSpeedMotor());
        }

        private IEnumerator SetSpeedMotor()
        {
            JointMotor2D jointMotor2D = new JointMotor2D();
            jointMotor2D.motorSpeed = _slider.motor.motorSpeed == speedDown ? speedUp : speedDown;
            jointMotor2D.maxMotorTorque = 10000f;
            _slider.motor = jointMotor2D;
            yield return new WaitForSeconds(timeWait);

            StartCoroutine(SetSpeedMotor());
        }
    }
}
