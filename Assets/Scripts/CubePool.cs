using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    public static CubePool Instance { get; private set; }
    [SerializeField] private List<Cube> cubePrefabs;

    private Queue<Cube> cubes = new Queue<Cube>();


    private void Awake()
    {
        Instance = this;
        AddCube(50);
    }
    public Cube GetCube()
    {
        if (cubes.Count == 0)
            AddCube(1);

        return cubes.Dequeue();
    }

    private void AddCube(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var cubeType = Random.Range(0, cubePrefabs.Count);
            Cube cube = Instantiate(cubePrefabs[cubeType]);
            cube.Type = cubeType;
            cube.gameObject.SetActive(false);
            cubes.Enqueue(cube);
            cube.gameObject.transform.SetParent(transform);
        }
    }
    public void RetunToPool(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cubes.Enqueue(cube);
        cube.gameObject.transform.SetParent(transform);
    }
    public int GetCubeTypeCount()
    {
        return cubePrefabs.Count;
    }
}
