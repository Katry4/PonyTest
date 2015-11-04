using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public GameObject dogPref, ponyPref;

    public Text poniesSavedText, timerText; 
    private int poniesSaved = 0;
    private float timeSinceStartup;
    private string timeFormat = "{0:0}:{1:00}";


    // Use this for initialization
    void Start () {
        dogPref.CreatePool(3);        
        
        for (int i=0; i < 3; i++)
        {
            GameObject dog = dogPref.Spawn();
            dog.GetComponent<DogScript>().InitInRandomPlace();
        }


        ponyPref.CreatePool(10);
        for (int i = 0; i < 10; i++)
        {
            GameObject pony = ponyPref.Spawn();
            pony.GetComponent<PonyScript>().InitInRandomPlace();
        }
    }

    public void OnPoniesSaved(int count)
    {
        poniesSaved += count;
        poniesSavedText.text = poniesSaved.ToString();
    }

    public void Update()
    {
        timeSinceStartup += Time.deltaTime;

        var time = timeSinceStartup;
        var minutes = Mathf.FloorToInt(time / 60F);
        var seconds = Mathf.FloorToInt(time - minutes * 60);

        timerText.text = string.Format(timeFormat, minutes, seconds);
    }
}
