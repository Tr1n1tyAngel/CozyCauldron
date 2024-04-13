using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FamiliarSpawner : MonoBehaviour
{
    //public Familiar[] familiars; // Array of character prefabs
    public Transform spawnPoint;
    public bool f1;
    public bool f2;
    public bool f3;
    public bool f4;
    public int chosenFamiliar;

    //private List<Familiar> spawnedFamiliars = new List<Familiar>(); // List to hold references to spawned characters

    void Update()
    {

            
            if (f1 == true)
            {
            SpawnFamiliar(0);
            f1 = false;
            }
            if (f2 == true)
            {
            SpawnFamiliar(1);
            f2 = false;
            }
            if (f3 == true)
            {
            SpawnFamiliar(2);
            f3 = false;
            }
            if (f4 == true)
            {
            SpawnFamiliar(3);
            f4 = false;
            }
    }

    void SpawnFamiliar(int index)
    {
        /*if (index < familiars.Length)
        {
            Familiar spawned = Instantiate(familiars[index], spawnPoint.position, Quaternion.identity);
            // Add the spawned character to the list of spawned characters
            spawnedFamiliars.Add(spawned);

            // Example call to method within the spawned character
            spawned.TryToFindItem();
        }
        else
        {
            Debug.LogError("Index out of range for spawning characters.");
        }*/
    }
}

   

