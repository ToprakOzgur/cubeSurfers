using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Tower tower;
    public GameObject character;

    [Space(10)]
    [Header("Movement Settings")]
    [Space(10)] [SerializeField] private float forwardSpeed = 0.5f;
    [Space(10)] [SerializeField] private float swipeSensitivity = 0.1f;


    private Platform platform;
    #region Unity Events

    void Awake()
    {
        platform = FindObjectOfType<Platform>();
    }
    void OnEnable()
    {
        InputController.OnDragEvent += MoveLeftRight;
    }
    void OnDisable()
    {
        InputController.OnDragEvent -= MoveLeftRight;
    }
    // Update is called once per frame
    void Update()
    {
        MoveForward();

    }
    #endregion

    #region movement
    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
    }
    private void MoveLeftRight(Vector2 delta)
    {
        var movementX = Time.deltaTime * swipeSensitivity * delta.x;

        if (IsOutsideBorders(movementX))
            return;

        transform.position += Vector3.right * movementX;
    }
    private bool IsOutsideBorders(float movementX)
    {
        return transform.position.x + movementX < platform.LeftBorderPint ||
                transform.position.x + movementX > platform.RightBorderPint;
    }
    #endregion

    public void AddCubeToTower(Cube cube)
    {
        character.transform.position += Vector3.up * cube.Size;
        tower.transform.position += Vector3.up * cube.Size;
        cube.gameObject.transform.position = new Vector3(tower.gameObject.transform.position.x, cube.gameObject.transform.position.y, transform.position.z);
        cube.gameObject.transform.SetParent(tower.transform);
    }
}
