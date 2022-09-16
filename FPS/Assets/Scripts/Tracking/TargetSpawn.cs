using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public List<Transform> Posi = new List<Transform>();
    public GameObject target;

    public void SpawnTargets()
    {
        target=Instantiate(target, new Vector3(-0.5f, 6.5f, 11.08f), Quaternion.identity);
    }

    //public Vector3 RandomPositionL()
    //{
    //    return Posi[Random.Range(0, 4)].position;
    //}

    //public Vector3 RandomPositionR()
    //{
    //    return Posi[Random.Range(4, 8)].position;
    //}

}
