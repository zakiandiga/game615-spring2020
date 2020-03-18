using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    string playerColor = "White";
    Transform selectedPiece;
    Transform selectedSquare;

    void selectSquare(Transform square)
    {
        deselectSquare();
        selectedSquare = square;
        highlightValid();
    }

    void deselectSquare()
    {
        if (selectedSquare)  //if this function exist
        {
            selectedSquare.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0.0f);
            selectedSquare = null;
        }
        //selectedSquare = null;
    }

    void highlightValid()
    {
        selectedSquare.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 0.3f);
    }

    void highlightInvalid()
    {
        selectedSquare.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
    }
    void selectPiece(Transform piece)
    {
        deselectPiece();
        selectedPiece = piece;

        Renderer[] renderers = selectedPiece.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", new Color(0, 0.5f, 0, 0.2f));
        }
    }

    void deselectPiece()
    {
        if (selectedPiece)
        {
            Renderer[] renderers = selectedPiece.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.material.DisableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", Color.black);
            }
        }
        selectedPiece = null;
    }

    void movePiece()
    {
        if (selectedPiece && selectedSquare)
        {
            selectedPiece.position = selectedSquare.position;
            selectedSquare.GetComponent<SquareInfo>().piece = selectedPiece;
            selectedPiece.parent.GetComponent<SquareInfo>().piece = null;
            selectedPiece.parent = selectedSquare;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        List<string> layers = new List<string>();
        layers.Add("Square");
        layers.Add(playerColor);

        if (GameState.playersTurn && Physics.Raycast(ray, out hit, 100, LayerMask.GetMask(layers.ToArray())))
        {
            if (hit.transform.tag == "square" && selectedPiece)
            {

                selectSquare(hit.transform);
                if (GameState.isValidMove(selectedPiece, selectedSquare))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        movePiece();
                        deselectPiece();
                    }
                }
                else
                {
                    highlightInvalid();
                }       
            }

            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "chessPieces" && hit.transform.name.Contains(playerColor))
            {
                selectPiece(hit.transform);
                deselectSquare();

            }
        }


    }


}