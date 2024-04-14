using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Menu menu;
    public GameObject pauseCanvas;
    public void Resume()
    {
        AudioManager.instance.SetSFXVolume(1);
        AudioManager.instance.PlaySFX(0);
        menu.rbFreeze = false;
            Time.timeScale = 1f;
            pauseCanvas.SetActive(false);

    }
}
