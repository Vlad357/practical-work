using System.Collections;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    private SliderJoint2D _slider;

    private void Start()
    {
        _slider = GetComponent<SliderJoint2D>();
        StartCoroutine(setSpeedMotor());
    }

    private IEnumerator setSpeedMotor()
    {
        JointMotor2D jointMotor2D = new JointMotor2D();
        jointMotor2D.motorSpeed = _slider.motor.motorSpeed == 5f ? -5f : 5f;
        jointMotor2D.maxMotorTorque = 10000f;
        _slider.motor = jointMotor2D;
        yield return new WaitForSeconds(5f);

        StartCoroutine(setSpeedMotor());
    }
}
