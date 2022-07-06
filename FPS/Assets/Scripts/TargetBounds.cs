using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBounds : MonoBehaviour
{
    public static TargetBounds Instance;
    public GameObject Target;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Instantiate(Target, GetRandomPosition(), Quaternion.identity);
        Instantiate(Target, GetRandomPosition(), Quaternion.identity);
        Instantiate(Target, GetRandomPosition(), Quaternion.identity);
    }

    [SerializeField] BoxCollider col;

    public Vector3 GetRandomPosition()
    {
        Vector3 center = col.center + transform.position;

        float minX = center.x - col.size.x / 2f;
        float maxX = center.x + col.size.x / 2f;

        float minY = center.y - col.size.y / 2f;
        float maxY = center.y + col.size.y / 2f;

        float minZ = center.z - col.size.z / 2f;
        float maxZ = center.z + col.size.z / 2f;

        float RandomX = Random.Range(minX, maxX);
        float RandomY = Random.Range(minY, maxY);
        float RandomZ = Random.Range(minZ, maxZ);

        Vector3 RandomPosition = new Vector3(RandomX, RandomY, RandomZ);

        return RandomPosition;
    }
}
