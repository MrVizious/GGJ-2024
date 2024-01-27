using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Actor : ShowAgent
{
    private Vector3 lastPosition;
    private void Start()
    {
        lastPosition = transform.position;
    }
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        animator.SetFloat("Speed", (lastPosition - currentPosition).magnitude * 100f);
        lastPosition = currentPosition;
    }
}
