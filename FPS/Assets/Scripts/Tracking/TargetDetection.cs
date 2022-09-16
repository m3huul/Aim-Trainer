using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    public int score;
    public float MissTimeCount, HitTimeCount;
    public bool Paused;
    [SerializeField] private Camera cam;
    public Target_Tracking target;
    public MeshRenderer target_mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        target = Target_Tracking.FindObjectOfType<Target_Tracking>();
        if (target)
        {
            target_mat = target.gameObject.GetComponent<MeshRenderer>();
            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 100f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                if (hit.collider.tag == "Enemy2")
                {
                    if (!Paused)
                    {
                        HitTimeCount += Time.deltaTime;
                        score = score + 1;
                    }                   
                    target_mat.material.color = Color.red;
                }
                else
                {
                    if (!Paused)
                    {
                        MissTimeCount += Time.deltaTime;
                    }
                    target_mat.material.color = Color.blue;
                }
            }
        }
        
    }
}
