using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{

    public ControlledScript currentDog;
    Vector2 newPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                ControlledScript selectedDog = hit.collider.gameObject.GetComponent<ControlledScript>();
                if (selectedDog!=null)
                {
                    currentDog = selectedDog;
                    newPosition = Vector2.zero;
                }
            }

            else if (currentDog != null)
            {
                newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentDog.MoveTo(newPosition);
            }
        }
    }
}
