using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public List<Transform> Posi = new List<Transform>();
    public GameObject target;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    public void SpawnTargets()
    {
        target1 = Instantiate(target, Posi[Random.Range(0, 9)].transform.position, Quaternion.identity);
        target2 = Instantiate(target, Posi[Random.Range(9, 19)].transform.position, Quaternion.identity);
        target3 = Instantiate(target, Posi[Random.Range(19, 28)].transform.position, Quaternion.identity);
    }

    public void Awake()
    { 
        
    }
    public Vector3 RandomPosi()
    {
        
        int n = Random.Range(0, 28);
        
        while (Posi[n].position == target1.transform.position || Posi[n].position == target2.transform.position || Posi[n].position == target3.transform.position)
        {
            n = Random.Range(0, 28);
        }
        return Posi[n].position;
    }


}

