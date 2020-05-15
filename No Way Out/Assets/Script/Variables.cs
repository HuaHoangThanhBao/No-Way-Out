using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Variables {

    [System.NonSerialized]
    public float offset = 1.5f;
    [System.NonSerialized]
    public float forceX = 10;
    [System.NonSerialized]
    public float forceY = 6;

    [System.NonSerialized]
    public bool hitCollisionEdgeLeft;
    [System.NonSerialized]
    public bool hitCollisionEdgeRight;
    [System.NonSerialized]
    public bool hitEdgeLeft;
    [System.NonSerialized]
    public bool hitEdgeRight;
    [System.NonSerialized]
    public bool death;
}