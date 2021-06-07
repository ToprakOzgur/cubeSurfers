using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [Space(10)]
    [Header("Borders")]
    [Space(10)] [SerializeField] private Transform leftBorder;
    [Space(10)] [SerializeField] private Transform rightBorder;

    public float LeftBorderPint => leftBorder.position.x;
    public float RightBorderPint => rightBorder.position.x;



}
