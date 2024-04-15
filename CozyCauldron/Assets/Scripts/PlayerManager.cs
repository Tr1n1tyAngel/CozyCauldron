using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject cauldronManager;
    public GameObject pauseCanvas;
    public GameObject interact;
    public PlayerInventory playerInventory;
    private Rigidbody2D rb;
    public Menu menu;
    private bool cauldronRadius = false;
    public Animator animator;
    public int i1Added;
    public int i2Added;
    public int i3Added;
    public int i4Added;
    public FamiliarSpawner familiarSpawner;
    public AudioSource source;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menu.menuCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseCanvas.SetActive(true);
                menu.rbFreeze = true;
                Time.timeScale = 0f;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        
        if(menu.rbFreeze==false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (cauldronRadius && playerMovement.isGrounded)
        {
            interact.SetActive(true);

            if(cauldronManager.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (playerInventory.ingredient1 != 0)
                    {
                        AudioManager.instance.SetSFXVolume(1f);
                        AudioManager.instance.PlaySFX(2);
                        Debug.Log("IADD");
                        playerInventory.ingredient1--;
                        i1Added++;

                    }

                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (playerInventory.ingredient2 != 0)
                    {
                        AudioManager.instance.SetSFXVolume(1f);
                        AudioManager.instance.PlaySFX(2);
                        Debug.Log("IADD");
                        playerInventory.ingredient2--;
                        i2Added++;

                    }

                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (playerInventory.ingredient3 != 0)
                    {
                        AudioManager.instance.SetSFXVolume(1f);
                        AudioManager.instance.PlaySFX(2);
                        Debug.Log("IADD");
                        playerInventory.ingredient3--;
                        i3Added++;

                    }

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (playerInventory.ingredient4 != 0)
                    {
                        AudioManager.instance.SetSFXVolume(1f);
                        AudioManager.instance.PlaySFX(2);
                        Debug.Log("IADD");
                        playerInventory.ingredient4--;
                        i4Added++;

                    }

                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    IngredientsSelected();
                }
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                source.Play();
                animator.SetBool("Stir",true);
                cauldronManager.SetActive(true);
                menu.rbFreeze = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                interact.SetActive(false);

            }
            
        }
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cauldron")) // Make sure the trigger is tagged as "ActionZone"
        {
            cauldronRadius = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cauldron"))
        {
            interact.SetActive(false);
            cauldronRadius = false;
        }
    }

    public void IngredientsSelected()
    {
        source.Stop();
        animator.SetBool("Stir", false);
            cauldronManager.SetActive(false);
            menu.rbFreeze = false;
        if (i1Added == 3 && i2Added == 3 && i3Added == 3 && i4Added == 3)
        {
            familiarSpawner.f1 = true;
            i1Added = 0;
            i2Added = 0;
            i3Added = 0;
            i4Added = 0;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
         if (i1Added == 5 && i2Added == 5 && i3Added == 5 && i4Added == 5)
        {
            familiarSpawner.f2 = true;
            i1Added = 0;
            i2Added = 0;
            i3Added = 0;
            i4Added = 0;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
        if (i1Added == 7 && i2Added == 7 && i3Added == 7 && i4Added == 7)
        {
            familiarSpawner.f3 = true;
            i1Added = 0;
            i2Added = 0;
            i3Added = 0;
            i4Added = 0;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
         if (i1Added == 10 && i2Added == 10 && i3Added == 10 && i4Added == 10)
        {
            familiarSpawner.f4 = true;
            i1Added = 0;
            i2Added = 0;
            i3Added = 0;
            i4Added = 0;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
        
        
    }
}
