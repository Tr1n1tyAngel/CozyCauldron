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
    public int[] f1Ingredients = new int[4];
    public int[] f2Ingredients = new int[4];
    public int[] f3Ingredients = new int[4];
    public int[] f4Ingredients = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for(int i = 0; i < f1Ingredients.Length;i++)
        {
            int rndif1 = Random.Range(3,6);
            f1Ingredients[i] = rndif1;
        }
        for (int i = 0; i < f2Ingredients.Length; i++)
        {
            int rndif2 = Random.Range(5, 8);
            f2Ingredients[i] = rndif2;
        }
        for (int i = 0; i < f3Ingredients.Length; i++)
        {
            int rndif3 = Random.Range(8, 11);
            f3Ingredients[i] = rndif3;
        }
        for (int i = 0; i < f4Ingredients.Length; i++)
        {
            int rndif4 = Random.Range(11, 14);
            f4Ingredients[i] = rndif4;
        }

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
        if (!cauldronManager.activeSelf)
        {
            i1Added = 0;
            i2Added = 0;
            i3Added = 0;
            i4Added = 0;
        }

            if (menu.rbFreeze==false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (cauldronRadius && playerMovement.isGrounded)
        {
            interact.SetActive(true);

            if(cauldronManager.activeSelf)
            {
                playerMovement.DisableInput();
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
                    playerMovement.EnableInput();
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
        if (i1Added == f1Ingredients[0] && i2Added == f1Ingredients[1] && i3Added == f1Ingredients[2] && i4Added == f1Ingredients[3]&& familiarSpawner.familiars[0])
        {
            familiarSpawner.f1 = true;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
         if (i1Added == f2Ingredients[0] && i2Added == f2Ingredients[1] && i3Added == f2Ingredients[2] && i4Added == f2Ingredients[3] && familiarSpawner.familiars[1])
        {
            familiarSpawner.f2 = true;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
        if (i1Added == f3Ingredients[0] && i2Added == f3Ingredients[1] && i3Added == f3Ingredients[2] && i4Added == f3Ingredients[3] && familiarSpawner.familiars[2])
        {
            familiarSpawner.f3 = true;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
         if (i1Added == f4Ingredients[0] && i2Added == f4Ingredients[1] && i3Added == f4Ingredients[2] && i4Added == f4Ingredients[3] && familiarSpawner.familiars[3])
        {
            familiarSpawner.f4 = true;
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(4);
        }
        else
        {
            AudioManager.instance.SetSFXVolume(1f);
            AudioManager.instance.PlaySFX(3);
        }
        i1Added = 0;
        i2Added = 0;
        i3Added = 0;
        i4Added = 0;

    }
}
