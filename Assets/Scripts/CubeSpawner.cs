using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDistance;
    private Platform platform;
    private void Awake()
    {
        platform = FindObjectOfType<Platform>();
    }
    private void Start()
    {
        SpawnCube();
        transform.position += Vector3.forward * spawnDistance;
    }

    private void SpawnCube()
    {
        var cube = CubePool.Instance.GetCube();

        cube.transform.position = new Vector3(GetRandomXPos(), transform.position.y, transform.position.z + spawnDistance);
        cube.gameObject.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            SpawnCube();
        transform.position += Vector3.forward * spawnDistance;

    }

    private float GetRandomXPos()
    {
        return Random.Range(platform.LeftBorderPint, platform.RightBorderPint);
    }
}

