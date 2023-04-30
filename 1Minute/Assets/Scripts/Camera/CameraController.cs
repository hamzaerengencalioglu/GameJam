using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerMovement player;

    public BoxCollider2D cameraBC;
    private float halfHeight, halfWidth;

    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(player.transform.position.x, cameraBC.bounds.min.x + halfWidth, cameraBC.bounds.max.x - halfWidth),
        Mathf.Clamp(player.transform.position.y, cameraBC.bounds.min.y + halfHeight, cameraBC.bounds.max.y - halfHeight),
        transform.position.z);
    }
}
