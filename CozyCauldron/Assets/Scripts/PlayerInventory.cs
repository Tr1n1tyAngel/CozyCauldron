using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public ItemFind[] itemFinds; // Array to hold multiple ItemFind objects
    public string itemFound;
    public int ingredient1;
    public int ingredient2;
    public int ingredient3;
    public int ingredient4;
    public TextMeshProUGUI ingredientGainedTxt;
    public TextMeshProUGUI i1CountTxt;
    public TextMeshProUGUI i2CountTxt;
    public TextMeshProUGUI i3CountTxt;
    public TextMeshProUGUI i4CountTxt;
    public Image ingImage;
    public Sprite i1;
    public Sprite i2;
    public Sprite i3;
    public Sprite i4;
    public Sprite i5;

    private void Update()
    {
        // Iterate through itemFinds to find the first one that is searching
        foreach (ItemFind itemFind in itemFinds)
        {
            if (itemFind.searching)
            {
                ProcessItemFind(itemFind);
                break; // Exit the loop after processing the first searching itemFind
            }
        }

        UpdateUI(); // Update the UI regardless of item searching status
    }

    private void ProcessItemFind(ItemFind itemFind)
    {
        // Process the item based on the given type
        switch (itemFind.itemToGive)
        {
            case 1:
                ingredient1 += itemFind.itemCount;
                itemFound = "Mushroom";
                ingImage.sprite = i1;
                break;
            case 2:
                ingredient2 += itemFind.itemCount;
                itemFound = "Eyeball";
                ingImage.sprite = i2;
                break;
            case 3:
                ingredient3 += itemFind.itemCount;
                itemFound = "Feather";
                ingImage.sprite = i3;
                break;
            case 4:
                ingredient4 += itemFind.itemCount;
                itemFound = "Rainbow Gem";
                ingImage.sprite = i4;
                break;
            case 5:
                ingredientGainedTxt.text = "No ingredients found";
                ingImage.sprite = i5;
                break;
        }
        itemFind.searching = false; // Set searching to false after processing

        if (itemFind.itemToGive != 5)
        {
            ingredientGainedTxt.text = itemFound + " " + itemFind.itemCount;
        }
    }

    private void UpdateUI()
    {
        i1CountTxt.text = ingredient1.ToString();
        i2CountTxt.text = ingredient2.ToString();
        i3CountTxt.text = ingredient3.ToString();
        i4CountTxt.text = ingredient4.ToString();
    }
}

