using System.Collections;
using UnityEngine;

public class ControlledScript : MonoBehaviour
{
    static readonly Vector3 idleVector = Vector3.one;

    enum Directions
    {
        Left = -1,
        Right = 1,
        Up = 2,
        Down = -2,
        Idle = 0
    }

    Vector3 startPos, targetPos;
    Animator animator;


    public float speed = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
        targetPos = idleVector;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPos != idleVector)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            if (transform.position == targetPos)
            {
                StopMoving();
            }
        }
    }

    internal void MoveTo(Vector2 newPosition)
    {
        startPos = transform.position;

        bool isMoving = targetPos != idleVector;
        targetPos = new Vector3(newPosition.x, newPosition.y, transform.position.z);

        float deltaX = targetPos.x - transform.position.x;
        float deltaY = targetPos.y - transform.position.y;

        int direction = (int)GetDirection(deltaX, deltaY);
        if (!isMoving || direction != animator.GetInteger("direction") )
        {
            animator.SetInteger("direction", direction);
            animator.SetTrigger("move");
        }
    }

    void StopMoving()
    {
        targetPos = idleVector;
        animator.SetTrigger("stop");
    }


    private Directions GetDirection(float dX, float dY)
    {
        if (Mathf.Abs(dX) > Mathf.Abs(dY))
        {
            if (dX > 0)
                return Directions.Right;
            else
                return Directions.Left;
        }
        else
        {
            if (dY > 0)
                return Directions.Up;
            else
                return Directions.Down;
        }
    }
}
