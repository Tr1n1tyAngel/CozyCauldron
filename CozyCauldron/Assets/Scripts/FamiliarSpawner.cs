using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FamiliarSpawner : MonoBehaviour
{
    public GameObject[] familiars;
    public bool f1;
    public bool f2;
    public bool f3;
    public bool f4;
    public int chosenFam;
    

    void Update()
    {

            
            if (f1 == true)
            {
            chosenFam = 0;
            familiars[chosenFam].SetActive(true);
            f1 = false;
            }
            if (f2 == true)
            {
            chosenFam = 1;
            familiars[chosenFam].SetActive(true);
            f2 = false;
            }
            if (f3 == true)
            {
            chosenFam = 2;
            familiars[chosenFam].SetActive(true);
            f3 = false;
            }
            if (f4 == true)
            {
            chosenFam = 3;
            familiars[chosenFam].SetActive(true);
            f4 = false;
            }
    }

    
}

   

