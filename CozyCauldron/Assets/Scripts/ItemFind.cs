using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemFind : MonoBehaviour
{
    private bool playerIsNear = false;
    private int searchAttempts = 0;  // To keep track of how many times the player has searched
    private float cooldownTimer = 0f;  // Timer to track the cooldown period
    public int itemToGive;
    public int itemCount;
    public SpriteRenderer spriteRenderer;
    public Sprite i1, i2, i3, i4;
    public GameObject itemDisplay;
    public PlayerManager playerManager;
    public bool searching;
    public GameObject timerCanvas;
    public TextMeshProUGUI timerText;
    

    private void Start()
    {
        ChooseRandomItem();
    }

    void Update()
    {
        // If the player is near and there is no cooldown active, allow searching
        if (playerIsNear && cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.E))
        {
            timerCanvas.SetActive(false);
            SearchAndGiveItem();
            
            
        }

        // Decrement the cooldown timer if it's active
        if (cooldownTimer > 0)
        {
            timerText.text = Mathf.FloorToInt(cooldownTimer) + " Seconds";
            cooldownTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerManager.interact.SetActive(true);
            playerIsNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerManager.interact.SetActive(false);
            playerIsNear = false;
        }
    }

    private void SearchAndGiveItem()
    {
        searchAttempts++;
        if (searchAttempts < 3)
        {
            TryToFindItem();
        }
        else if (searchAttempts == 3)
        {
            TryToFindItem();
            // Start cooldown timer after three searches
            timerCanvas.SetActive(true);
            cooldownTimer = 30.0f;
            searchAttempts = 0; // Reset search attempts
        }
    }

    private void TryToFindItem()
    {
        searching = true;
        if (Random.Range(1, 5) == 1)  // 1 in 4 chance
        {
            itemToGive = Random.Range(1, 5);
            itemCount = GetRandomItemCount();
            itemDisplay.SetActive(true);
            Invoke("DisplayReset", 2);
        }
        else
        {
            itemCount = 0;
            itemToGive = 5;
            Debug.Log("No items found.");
            itemDisplay.SetActive(true);
            Invoke("DisplayReset", 2);

        }
    }

    private int GetRandomItemCount()
    {
        // Weighted randomness for item count
        int rand = Random.Range(1, 101);
        if (rand <= 70) return 1;
        else if (rand <= 90) return 2;
        else return 3;
    }

    public void DisplayReset()
    {
        itemDisplay.SetActive(false);
    }

    private void ChooseRandomItem()
    {
        int rnd = Random.Range(1, 5);
        switch (rnd)
        {
            case 1:
                spriteRenderer.sprite = i1;
                break;
            case 2:
                spriteRenderer.sprite = i2;
                break;
            case 3:
                spriteRenderer.sprite = i3;
                break;
            case 4:
                spriteRenderer.sprite = i4;
                break;
        }
    }
}
