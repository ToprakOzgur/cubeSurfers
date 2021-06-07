using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Tower : MonoBehaviour
{
    private List<Cube> cubes = new List<Cube>();
    [HideInInspector] public Player player;
    public void AddCubeToBottom(Cube cube)
    {
        cubes.Add(cube);
        //moves all tower 1 unit up
        transform.position += Vector3.up * cube.Size;

        //moves cube positito tower bottom
        cube.gameObject.transform.position = new Vector3(transform.position.x, cube.gameObject.transform.position.y, transform.position.z);

        cube.gameObject.transform.SetParent(transform);

        //checking game logic
        CheckIfTowerHasAllColors();
    }

    private void CheckIfTowerHasAllColors()
    {
        var cubeTypeCount = CubePool.Instance.GetCubeTypeCount();

        for (int i = 0; i < cubeTypeCount; i++)
        {
            if (!cubes.Any(cube => cube.Type == i))
                return; //not all types available      
        }

        //all colos available
        Remove1CubeFofEachColor(cubeTypeCount);
    }

    private void Remove1CubeFofEachColor(int cubeTypeCount)
    {
        for (int i = 0; i < cubeTypeCount; i++)
        {
            var cube = cubes.First(x => x.Type == i);
            cubes.Remove(cube);
            var allAboveCubes = cubes.Where(x => x.transform.position.y > cube.transform.position.y);
            allAboveCubes.ToList().ForEach(x => x.MoveDown());
            CubePool.Instance.RetunToPool(cube);
            player.MoveCharacterDown(cube.Size);

        }
    }
}
