using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Camera camera;
    public GameObject menuCanvas;
    public Rigidbody2D rb;
    public bool rbFreeze = false;
    public GameObject outsideWall;

    private void Start()
    {
        rbFreeze = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Time.timeScale = 0f;
    }
    private void Update()
    {
        if (rbFreeze == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }
    public void GameStart()
    {
        outsideWall.SetActive(false);
        rbFreeze = false;
        Time.timeScale = 1f;
        menuCanvas.SetActive(false);
        camera.orthographicSize = 3;
        camera.transform.position = new Vector3(0,-1.15f,-10);
        
    }
    public void GameQuit()
    {
        Application.Quit();
    }


}
