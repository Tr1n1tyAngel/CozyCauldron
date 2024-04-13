using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera gameCamera; // Reference to the game Camera
    public float smoothSpeed = 1f; // Smoothing speed for the camera movement
    private bool isCameraAttached = false; // Flag to check if the camera is attached to the player
    private Vector3 initialCameraPosition; // To store the initial position of the camera
    public Vector3 aSmoothedPosition;
    public Menu menu;

    void Start()
    {
        // Check if the camera is assigned
        if (gameCamera == null)
        {
            Debug.LogError("Camera not assigned in the inspector.");
            return;
        }

        // Store the initial position of the camera
        initialCameraPosition = new Vector3(0, -1.15f, -10); ;
    }

    void FixedUpdate()
    {
        if (isCameraAttached)
        {
            
            // Calculate the new position for the camera with only horizontal movement
            Vector3 targetPosition = new Vector3(transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
            // Smoothly move the camera towards the target position
            Vector3 smoothedPosition = Vector3.Lerp(gameCamera.transform.position, targetPosition, smoothSpeed * Time.fixedDeltaTime);
            // Apply the smoothed position
            gameCamera.transform.position = smoothedPosition;
        }
        else
        {
            
            // Smoothly move the camera back to the initial position when detached
            aSmoothedPosition = Vector3.Lerp(gameCamera.transform.position, initialCameraPosition, smoothSpeed * Time.fixedDeltaTime);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Toggle camera attachment on trigger enter
        if (other.tag == "CameraTrigger") 
        {
            Debug.Log("Check");
            isCameraAttached = !isCameraAttached;  // Toggle the camera attachment state
            if(isCameraAttached==false)
            {
                menu.outsideWall.SetActive(false);
                gameCamera.orthographicSize = 3;
                gameCamera.transform.position = new Vector3(0, -1.15f, -10);
                gameCamera.transform.position = aSmoothedPosition;

            }
            else
            {
                menu.outsideWall.SetActive(true);
                
                gameCamera.orthographicSize = 5;
                gameCamera.transform.position = new Vector3(0, 0, -10);
            }
        }
    }
}

