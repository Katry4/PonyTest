using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


    public GameObject dogPref, ponyPref;

    private List<DogScript> dogs;
    private List<PonyScript> ponies;

	// Use this for initialization
	void Start () {
        dogs = new List<DogScript>();
        dogPref.CreatePool(3);        
        
        for (int i=0; i < 3; i++)
        {
            GameObject dog = dogPref.Spawn();
            dog.GetComponent<DogScript>().InitInRandomPlace();
        }



        ponies = new List<PonyScript>();
        ponyPref.CreatePool(10);
        for (int i = 0; i < 10; i++)
        {
            GameObject pony = ponyPref.Spawn();
            pony.GetComponent<PonyScript>().InitInRandomPlace();
        }
    }



	
}
