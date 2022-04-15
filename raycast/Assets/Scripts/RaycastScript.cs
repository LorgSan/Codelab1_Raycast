using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastScript : MonoBehaviour
{
    float sphereRadius = 0.09f;
    public Camera cam;
    public Image crosshair;
    Material ChosenMaterial;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyePosition = transform.position;
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = cam.nearClipPlane;

        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos);

        Vector3 dir = mouseWorldPos - eyePosition;

        dir.Normalize();

        RaycastHit hitter = new RaycastHit();

        Debug.DrawLine(eyePosition, dir * 20f, Color.red);

        if(Physics.SphereCast(eyePosition, sphereRadius, dir, out hitter))
            {
                if (Input.GetMouseButton(0) && hitter.collider.gameObject.tag == "Color")
                {
                    GameObject colorObject = hitter.collider.gameObject;
                    ChosenMaterial = colorObject.GetComponent<Renderer>().material;
                    Debug.Log(ChosenMaterial);
                    crosshair.color = ChosenMaterial.color;

                }

                if (Input.GetMouseButton(0) && hitter.collider.gameObject.tag == "Interactable")
                {
                    Debug.Log("interactable chosen");
                    GameObject Interactable = hitter.collider.gameObject;
                    Interactable.GetComponent<Renderer>().material = ChosenMaterial;
                }

            }
    }
}
