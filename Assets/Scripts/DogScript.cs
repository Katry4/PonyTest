using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DogScript : ControlledScript
{
    List<PonyScript> followedPony;


    protected override void Start()
    {
        base.Start();
        followedPony = new List<PonyScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnCollision enter "+col);
        if (col.gameObject.tag == "Pony")
        {
            PickUpPony(col.gameObject);
        }
    }

    private void PickUpPony(GameObject ponyObj)
    {
        Debug.Log("Pony catched");
        PonyScript ponyScript = ponyObj.GetComponent<PonyScript>();
        followedPony.Add(ponyScript);
        ponyScript.OnCollideWithDog(gameObject);
        ponyScript.FollowDogTo(targetPos);

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
