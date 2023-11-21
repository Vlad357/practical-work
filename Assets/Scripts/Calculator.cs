using System;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public InputField firstInput;
    public InputField secondInput;
    public Text result;

    public void Add()
    {
        if(firstInput != null && secondInput != null)
        {
            result.text = (Convert.ToInt32(firstInput.text) + Convert.ToInt32(secondInput.text)).ToString();
        }
    }
    public void Subtraction()
    {
        if (firstInput != null && secondInput != null)
        {
            result.text = (Convert.ToInt32(firstInput.text) - Convert.ToInt32(secondInput.text)).ToString();
        }
    }
    public void Multyply()
    {
        if (firstInput != null && secondInput != null)
        {
            result.text = (Convert.ToInt32(firstInput.text) * Convert.ToInt32(secondInput.text)).ToString();
        }
    }
    public void Division()
    {
        if (firstInput != null && secondInput != null)
        {
            result.text = (Convert.ToInt32(firstInput.text) / Convert.ToInt32(secondInput.text)).ToString();
        }
    }
}
