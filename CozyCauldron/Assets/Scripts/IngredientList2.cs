using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IngredientList2 : MonoBehaviour
{
    public bool ingredientRadius = false;
    public GameObject interact;
    public GameObject ingredientsCanvas;
    public Rigidbody2D rb;
    public Menu menu;
    public TextMeshProUGUI ingredientsTxt;
    public PlayerMovement playerMovement;
    public PlayerManager playerManager;
    private void Update()
    {
        if (ingredientRadius && playerMovement.isGrounded)
        {
            interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerMovement.DisableInput();
                AudioManager.instance.SetSFXVolume(1);
                AudioManager.instance.PlaySFX(1);
                ingredientsTxt.text = "The ingredients you need to get the Ghost familiar are: \n" + playerManager.f2Ingredients[0] + " Mushrooms \n" + playerManager.f2Ingredients[1] + " Eyeballs \n" + playerManager.f2Ingredients[2] + " Rainbow Gems \n" + playerManager.f2Ingredients[3] + "Feathers";
                ingredientsCanvas.SetActive(true);
                menu.rbFreeze = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                interact.SetActive(false);

            }
        }


    }


    public void LeaveIngredients()
    {
        AudioManager.instance.SetSFXVolume(1);
        AudioManager.instance.PlaySFX(1);
        ingredientsCanvas.SetActive(false);
        menu.rbFreeze = false;
        playerMovement.EnableInput();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure the trigger is tagged as "ActionZone"
        {
            ingredientRadius = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interact.SetActive(false);
            ingredientRadius = false;
        }
    }
}
