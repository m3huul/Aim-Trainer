using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private Vector2 sens;

    private Vector2 rotation;

    [SerializeField]
    private SettingsScript settings;

    
    public int shotsFired=0;
    
    void Start()
    {
        
    }

    private Vector2 GetInput()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"));
        return input;
    }
    private void Update()
    {
        sens.x = settings.MouseSens;
        sens.y = -settings.MouseSens;
        Vector2 wantedVelocity = GetInput() * sens *500;

        rotation += wantedVelocity * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x,0f);

        
        if (Input.GetButtonDown("Fire1"))
        {
            shotsFired=++shotsFired;
        }
    }
}