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
        if (cauldronRadius)
        {
            interact.SetActive(true);

            if(cauldronManager.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (playerInventory.ingredient1 != 0)
                    {
                        Debug.Log("IADD");
                        playerInventory.ingredient1--;
                        i1Added++;

                    }

                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (playerInventory.ingredient2 != 0)
                    {
                        Debug.Log("IADD");
                        playerInventory.ingredient2--;
                        i2Added++;

                    }

                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (playerInventory.ingredient3 != 0)
                    {
                        Debug.Log("IADD");
                        playerInventory.ingredient3--;
                        i3Added++;

                    }

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (playerInventory.ingredient4 != 0)
                    {
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
            animator.SetBool("Stir", false);
            cauldronManager.SetActive(false);
            menu.rbFreeze = false;
        if (i1Added == 1)
        {
            familiarSpawner.f1 = true;
        }
         if (i2Added == 1)
        {
            familiarSpawner.f2 = true;
        }
         if (i3Added == 1)
        {
            familiarSpawner.f3 = true;
        }
         if (i4Added == 1)
        {
            familiarSpawner.f4 = true;
        }
        
        
    }
}
