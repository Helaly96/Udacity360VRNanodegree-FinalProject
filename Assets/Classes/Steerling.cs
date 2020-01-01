using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this will store the data about player's position

public class Steering
{ 
    public float angular;
    public Vector3 linear;
    public Steering()
    {
        angular = 0.0f;
        linear = new Vector3(); 
    } 
}