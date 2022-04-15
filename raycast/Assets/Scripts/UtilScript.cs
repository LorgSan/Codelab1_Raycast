using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilScript
{

    public static Vector3 RandomizeVector(Vector3 min, Vector3 max)
    {
        //we just randomize each value between given min znd max
        Vector3 myVector = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)); 
        return myVector;
    }

}
