using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**************
File: MainColliderScript.cs
Author: Liam Blake
Created: 2020-12-15
Modified: 2020-12-15
Desc:
    Manager for the main collider. This script is responsible for moving the platform back and fourth on y from its local position. This trigger does NOT
    shrink with the platform child component. Or else, if scale.x goes down to zero, then we can't grow it again because the trigger doesn't exist anymore! 
    This script solves that problem.
**************/
// More contexual rather than using bools or flags (integers):
public enum State
{
    None,
    Grow,
    Shrink
}

public class MainColliderScript : MonoBehaviour
{
    [Header("Factors")]
    [SerializeField]
    float hoverSpeed;

    private Vector3 originalPos;
    private float time = 0.0f;
    public State state;
    public bool isPlayerColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }
    // Synced with the physics engine
    void FixedUpdate()
    {
        _Move();
    }
    private void _Move()
    {
        time += Time.deltaTime * hoverSpeed;
        transform.position = originalPos + new Vector3(0.0f, Mathf.Sin(time), 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerColliding = false;
        }
    }
}
