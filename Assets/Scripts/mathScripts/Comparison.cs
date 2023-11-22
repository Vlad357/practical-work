using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparison : MonoBehaviour
{
    public InputField firstInput;
    public InputField secondInput;
    public Text result;

    public void ComparisonNums()
    {
        if (firstInput != null && secondInput != null)
        {
            if (firstInput.text.Equals(secondInput.text))
            {
                result.text = "equals";
            }
            else if (Convert.ToInt32(firstInput.text) < Convert.ToInt32(secondInput.text))
            {
                result.text = secondInput.text;
            }
            else
            {
                result.text = firstInput.text;
            }
        }
    }
}
