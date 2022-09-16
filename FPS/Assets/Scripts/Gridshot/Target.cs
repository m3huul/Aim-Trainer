using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public TargetSpawner spawner;
    private void Start()
    {
        spawner = TargetSpawner.FindObjectOfType<TargetSpawner>();
    }
    public void Hit()
    {      
        transform.position = spawner.RandomPosi();
        
    }
}
