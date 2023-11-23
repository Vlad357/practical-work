using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int z;

    public TextMeshProUGUI textCharacteristics;

    public void ApplyTool()
    {
        GameManager.instance.UseTool(x, y, z);
    }

    private void Start()
    {
        textCharacteristics.text = $"{x}|{y}|{z}";
    }
}
