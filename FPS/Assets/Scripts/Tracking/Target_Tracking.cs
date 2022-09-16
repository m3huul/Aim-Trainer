using System.Collections;
using UnityEngine;

public class Target_Tracking : MonoBehaviour
{
    public TargetSpawn spawn;
    public GameObject Pos1, Pos2;
    Vector3 endPosi;
    public Rigidbody rb;
    public MeshRenderer mesh;
    public int sped;
    public bool _check=true;

    private void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        spawn = TargetSpawn.FindObjectOfType<TargetSpawn>();
    }
    private void Update()
    {
        if (_check)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawn.Posi[0].position, sped * Time.deltaTime);
            if (transform.position.x == spawn.Posi[0].position.x)
            {
                _check = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, spawn.Posi[1].position, sped * Time.deltaTime);

            if (transform.position.x == spawn.Posi[1].position.x)
            {
                _check = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        sped = Random.Range(2, 15);
    }

    public MeshRenderer MeshRenderer
    {
        get { return mesh; }
        set { mesh = value; }
    }
}

