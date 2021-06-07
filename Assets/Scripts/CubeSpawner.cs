using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{


    private void Start()
    {


        for (int i = 2; i < 50; i++)
        {
            Debug.Log("swan");
            var cube = CubePool.Instance.GetCube();

            cube.transform.position = new Vector3(this.transform.position.x, transform.position.y, transform.position.z + i);
            cube.gameObject.SetActive(true);
        }


    }
}
