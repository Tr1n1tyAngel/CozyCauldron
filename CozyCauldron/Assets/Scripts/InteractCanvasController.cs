using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCanvasController : MonoBehaviour
{
    public Transform player; // Reference to the player Transform
    public Vector3 offset; // Offset to keep the canvas in the correct position relative to the player

    void Update()
    {
        // Adjust only the position of the canvas
        transform.position = player.position + offset;
    }
}
