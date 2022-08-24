using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SettingsScript : ScriptableObject 
{
    

    [SerializeField]
    private float _MouseSens;

    [SerializeField]
    private int _crosshairColorValue;

    [SerializeField]
    private int _crosshairTypeValue;

    [SerializeField]
    private Color _crosshairColor;


    public float MouseSens
    {
        get { return _MouseSens;  }
        set { _MouseSens = value; }
    }

    public int crosshairColorValue
    {
        get { return _crosshairColorValue; }
        set { _crosshairColorValue = value; }
    }

    public Color crosshairColor
    {
        get { return _crosshairColor; }
        set { _crosshairColor = value; }
    }
    public int crosshairtypeValue
    {
        get { return _crosshairTypeValue; }
        set { _crosshairTypeValue = value; }
    }

}
