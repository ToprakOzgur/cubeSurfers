using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;

    public float LeftBorderPint => leftBorder.position.x;
    public float RightBorderPint => rightBorder.position.x;

}
