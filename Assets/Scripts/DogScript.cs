using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DogScript : ControlledScript
{
    List<PonyScript> followedPony;
    Rigidbody2D rb;

    protected override void OnEnable()
    {
        base.OnEnable();
        followedPony = new List<PonyScript>();
        rb = GetComponent<Rigidbody2D>();    
    }

    internal override void Init()
    {
        base.Init();
        followedPony = new List<PonyScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pony")
        {
            PickUpPony(col.gameObject);
        }
    }

    private void PickUpPony(GameObject ponyObj)
    {
        PonyScript ponyScript = ponyObj.GetComponent<PonyScript>();
        if (ponyScript != null && targetPos!= idleVector)
        {
            followedPony.Add(ponyScript);
            ponyScript.OnCollideWithDog(gameObject);
            ponyScript.FollowDogTo(targetPos);
        }
    }

    private void LeaveAllPony()
    {

    }

    public override void MoveTo(Vector2 newPosition)
    {
        base.MoveTo(newPosition);

        foreach (PonyScript pony in followedPony)
        {
            pony.FollowDogTo(newPosition);
        }
    }
}
