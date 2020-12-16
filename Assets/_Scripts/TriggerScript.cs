using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**************
File: TriggerScript.cs
Author: Liam Blake
Created: 2020-12-15
Modified: 2020-12-15
Desc:
    Manager for the player trigger. Upon collision the parent is called and goes into "shrink" state and vise versa when leaving it.
    This is done with a seperate script because we need two seperate colliders. One is the physical rigid body and this one is the trigger that
    activates the shrink/grow state. We don't want the platform to shrink the platform if the player collides with it from underneath. Only if the player lands on it.
**************/
public class TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Call parent
            transform.parent.GetComponent<PlatformScript>().OnEnter();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Call parent
            transform.parent.GetComponent<PlatformScript>().OnExit();
        }
    }
}
