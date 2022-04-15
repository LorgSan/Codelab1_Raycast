using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastScript : MonoBehaviour
{
    float sphereRadius = 0.1f; //how big the cursor is (or a imaginative sphere around it that makes it easier for us to click on stuff)
    public Camera cam; //camera (for some reason it wasn't fetching the main camera, probably because it's buries as a child so I have that)
    public Image crosshair; //crosshair ui element
    public Material ChosenMaterial; //remember the material we're holding

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyePosition = transform.position; //this will be our raycast starting position
        Vector3 mousePos = Input.mousePosition; 

        mousePos.z = cam.nearClipPlane; //nearest plain in the camera frustrum (because it's looking at an angle)

        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos); //saving the position of the coursor

        Vector3 dir = mouseWorldPos - eyePosition; //saving the direction, which is a subtraction between our current position and where our mouse is

        dir.Normalize(); //tbh I don't remember why we're doing it :(

        RaycastHit hitter = new RaycastHit(); //creating a new hitter

        Debug.DrawLine(eyePosition, dir * 20f, Color.red); //editor tracing

        if(Physics.SphereCast(eyePosition, sphereRadius, dir, out hitter)) //the spherecast returns a raycasthit of whatever it's 
        //looking at right now from our position in the direction of dir. sphereRadius is just how big the hit counts as true
            {
                if (Input.GetMouseButton(0) && hitter.collider.gameObject.tag == "Color") //if there's a gameObject tagged as Color
                {
                    GameObject colorObject = hitter.collider.gameObject; //remember the hitter
                    ChosenMaterial = colorObject.GetComponent<Renderer>().material; //get the material that this object has
                    //Debug.Log(ChosenMaterial); 
                    crosshair.color = ChosenMaterial.color; //change the color of the crosshair to the chosen material

                }

                if (Input.GetMouseButton(0) && hitter.collider.gameObject.tag == "Interactable") //if we hit something interactible 
                {
                    //Debug.Log("interactable chosen");
                    GameObject Interactable = hitter.collider.gameObject;
                    Interactable.GetComponent<Renderer>().material = ChosenMaterial; //just set it's material as the one we have chosen
                    //if we didn't chose anything it's gonna get chosen to white which is default
                }

            }
    }
}
