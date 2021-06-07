using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Cube : MonoBehaviour, ICollactable
{

    public BoxCollider boxCollider { get; private set; }
    private int type;
    public int Type
    {
        get { return type; }
        set { type = value; }
    }

    private float size;
    public float Size
    {
        get { return size; }
        set { size = value; }
    }
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        Size = boxCollider.bounds.size.y;
        Debug.Log(size);
    }
    private void OnEnable()
    {
        boxCollider.enabled = true;
    }
    public void DisableTrigger()
    {
        boxCollider.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DisableTrigger();

            other.gameObject.GetComponent<Player>().AddCubeToTower(this);

        }
    }
}
