using UnityEngine;
using System.Collections;
using System;

public class PonyScript : ControlledScript
{

    public float delayBeforeMove = 1f;
    public float maxDogOffset = 1.5f;

    GameObject dogToFollow;

    #region Init

    internal override void Init()
    {
        base.Init();
    }

    internal override void Recycle()
    {
        base.Recycle();
        dogToFollow = null;
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    #endregion

    internal void OnLeaved()
    {

    }

    internal void OnCollideWithDog(GameObject dog)
    {
        dogToFollow = dog;
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public override void MoveTo(Vector2 newPosition)
    {
        base.MoveTo(newPosition);
    }

    public void FollowDogTo(Vector2 targetPosition)
    {
        StartCoroutine(DelayBeforeMove(targetPosition));
    }

    IEnumerator DelayBeforeMove(Vector2 targetPosition)
    {
        yield return new WaitForSeconds(delayBeforeMove);
        float x = UnityEngine.Random.Range(-maxDogOffset, maxDogOffset);
        float y = UnityEngine.Random.Range(-maxDogOffset, maxDogOffset);
        MoveTo(targetPosition + new Vector2(x, y));
    }
}
