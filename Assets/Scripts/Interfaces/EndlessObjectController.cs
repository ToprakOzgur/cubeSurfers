using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EndlessObjectController : MonoBehaviour
{
    [SerializeField] private float offset;
    private float size;
    private void Awake()
    {
        size = GetComponent<Renderer>().bounds.size.z;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position += new Vector3(0, 0, (size - offset) * 2);
        }
    }
}
