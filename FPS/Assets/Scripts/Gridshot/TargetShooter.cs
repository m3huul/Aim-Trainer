using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public int TargetHit=0;
    public int multiplier=1;
    public int score;
    void Update()
    {
        Target target;
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 10f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            { 
                target = hit.collider.gameObject.GetComponent<Target>();
                
                if (hit.collider.tag=="Enemy")
                {
                    TargetHit=++TargetHit;
                    target.Hit();
                    score = 100 * multiplier + score;
                    multiplier = ++multiplier;    
                }
                else
                {
                    multiplier = 1;
                }
            }
            
        }
        
    }



}
