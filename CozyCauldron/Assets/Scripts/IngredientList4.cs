using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IngredientList4 : MonoBehaviour
{
    public bool ingredientRadius = false;
    public GameObject interact;
    public GameObject ingredientsCanvas;
    public Rigidbody2D rb;
    public Menu menu;
    public TextMeshProUGUI ingredientsTxt;
    private void Update()
    {
        if (ingredientRadius)
        {
            
            interact.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.SetSFXVolume(1);
                AudioManager.instance.PlaySFX(1);
                ingredientsTxt.text = "The ingredients you need to get the Neco familiar are: \n10 Mushrooms \n10 Eyeballs \n10 Rainbow Gems \n10 Feathers";
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
