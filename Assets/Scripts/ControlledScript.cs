using System;
using UnityEngine;

public class ControlledScript : MonoBehaviour
{

    public BoxCollider2D spawnableArea, unspawnableArea;


    public static readonly Vector3 idleVector = Vector3.one;

    enum Directions
    {
        Left = -1,
        Right = 1,
        Up = 2,
        Down = -2,
        Idle = 0
    }

    internal Vector3 startPos, targetPos;
    Animator animator;


    public float speed = 1.5f;

    #region Init
    protected virtual void OnEnable()
    {
        animator = GetComponent<Animator>();
    }



    internal virtual void InitInRandomPlace()
    {
        InitIn(GetPositionToSpawn());
    }

    internal virtual void InitIn(Vector2 pos)
    {
        Init();
        transform.position = pos;
    }

    internal virtual void Init()
    {
        startPos = transform.position;
        targetPos = idleVector;

        gameObject.SetActive(true);
    }
    private Vector2 GetPositionToSpawn()
    {
        Vector2 res;
        float x, y;
        float leftX = spawnableArea.transform.position.x  -spawnableArea.size.x / 2f;
        float rightX = spawnableArea.transform.position.x + spawnableArea.size.x / 2f;
        float leftY = spawnableArea.transform.position.y - spawnableArea.size.y / 2f;
        float rightY = spawnableArea.transform.position.y + spawnableArea.size.y / 2f;

        Rect unRect = new Rect(unspawnableArea.transform.position, unspawnableArea.size);
        do
        {
            x = UnityEngine.Random.Range(leftX, rightX);
            y = UnityEngine.Random.Range(leftY, rightY);

            res = new Vector2(x, y);

            // unspawnableArea.OverlapPoint(res)
            // unRect.Contains(res)

            // there is odd results sometimes.
        } while (unRect.Contains(res));

        return res;
    }

    internal virtual void Recycle()
    {
    }

    #endregion

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

    public virtual void MoveTo(Vector2 newPosition)
    {
        startPos = transform.position;

        bool isMoving = targetPos != idleVector;
        targetPos = new Vector3(newPosition.x, newPosition.y, transform.position.z);

        float deltaX = targetPos.x - transform.position.x;
        float deltaY = targetPos.y - transform.position.y;

        int direction = (int)GetDirection(deltaX, deltaY);
        if (!isMoving || direction != animator.GetInteger("direction"))
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
