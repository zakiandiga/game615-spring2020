using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Transform selectedPiece;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "square")
                {
                    Renderer[] renderers = selectedPiece.transform.GetComponentsInChildren<Renderer>(); //collection of object value variable

                    hit.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.4f);
                    if (selectedPiece) //shortcut to (selectedPiece != null)
                    {
                        selectedPiece.position = hit.transform.position;
                        selectedPiece.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                        selectedPiece = null;
                        
                    }
                }
                if (hit.transform.tag == "chessPieces")
                {
                    Renderer[] renderers = hit.transform.GetComponentsInChildren<Renderer>(); //collection of object value variable
                    selectedPiece = hit.transform;

                    foreach (Renderer r in renderers)
                    {
                        r.material.SetColor("_EmissionColor", new Color(1, 0, 0));
                        r.material.EnableKeyword("_EMISSION");
                    }
                    //hit.transform.GetComponentsInChildren<Renderer>().material.SetColor("_EmissionColor", new Color(1, 0, 0)); //color = new Color(1, 0, 0);
                    //hit.transform.GetComponentsInChildren<Renderer>().material.EnableKeyword("_EMISSION");
                    //Debug.Log("Last Line");
                }
            }
            
        }
    }
}
