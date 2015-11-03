using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{

    public DogScript currentDog;
    public LayerMask dogLayer;
    Vector2 newPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100,dogLayer);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Dog")
                {
                    currentDog = hit.collider.gameObject.GetComponent<DogScript>();
                    newPosition = Vector2.zero;
                }
            }
            else
            TryMoveDog();

        }
    }

    private void TryMoveDog()
    {
        if (currentDog != null)
        {
            newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentDog.MoveTo(newPosition);
        }
    }
}
