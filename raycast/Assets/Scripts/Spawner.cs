using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   

    public float amount;
    public Object[] interactables;
    public Vector3 min;
    public Vector3 max;

    // Start is called before the first frame update
    void Start()
    {

        //here we just instantiate amount of objects consisting of different object from the resources folder, which are getting
        // remembered in a interctables array in the beginning. they are chosen and placed on the scene randomly
        //but within a specific range (see UtilScript)

        interactables = Resources.LoadAll("", typeof(Object));

        for(int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, interactables.Length);
            //Debug.Log(interactables[index]);
            //Debug.Log(index);
            Vector3 newPos = UtilScript.RandomizeVector(min, max);
            GameObject interactable = Instantiate(interactables[index] as GameObject, newPos, Quaternion.identity);
            interactable.transform.parent = transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
