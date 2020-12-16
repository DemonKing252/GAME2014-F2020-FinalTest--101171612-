using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**************
File: PlatformScript.cs
Author: Liam Blake
Created: 2020-12-15
Modified: 2020-12-15
Desc:
    Manager for shrinking and growing the platform. Also handles audio.
**************/
public class PlatformScript : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField]
    AudioSource grow;
    [SerializeField]
    AudioSource shrink;

    [Header("Size Factors")]
    [SerializeField]
    float sizeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _CheckStates();   
    }
    private void _CheckStates()
    {
        // Reset if the scale becomes zero. Since the trigger no longer exists
        if (transform.localScale.x == 0.0f && !transform.parent.GetComponent<MainColliderScript>().isPlayerColliding)
        {
            transform.parent.GetComponent<MainColliderScript>().state = State.Grow;
            grow.Play();
        }
        // Increase local scale
        if(transform.parent.GetComponent<MainColliderScript>().state == State.Grow)
        {
            transform.localScale += new Vector3(Time.deltaTime * sizeSpeed, 0.0f, 0.0f);
        }
        // Decrease local scale
        else if (transform.parent.GetComponent<MainColliderScript>().state == State.Shrink)
        {
            transform.localScale -= new Vector3(Time.deltaTime * sizeSpeed, 0.0f, 0.0f);
        }
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 0.0f, 1.0f), 1.0f, 1.0f);
    }
    public void OnEnter()
    {
        // Grow sound
        transform.parent.GetComponent<MainColliderScript>().state = State.Shrink;
        grow.Play();
    }
    public void OnExit()
    {
        // Shrink sound
        transform.parent.GetComponent<MainColliderScript>().state = State.Grow;
        shrink.Play();
    }

}
