using UnityEngine;
using System.Collections;

public class SafeZoneScript : MonoBehaviour {

    public GameManager gameManager; 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Dog")
        {
            int count = col.gameObject.GetComponent<DogScript>().LeaveAllPony();
            gameManager.OnPoniesSaved(count);
        }
    }
}
