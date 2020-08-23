using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    string playerColor = "White";
    public static bool playersTurn = true;
    public static Transform[,] chessboard = new Transform [8,8];
    public GameObject baseCube;
    public Transform boardParent;
    public Transform chessPiece;
    const int SQUARE_SIZE = 2;
    List<Transform> activeWhitePiece = new List<Transform>();
    List<string> activeWhitePiecesNames = new List<string>();

    static bool isPathEmpty(Transform piece, Transform square, float maxDistance)
    {
        RaycastHit hit;
        Debug.DrawRay(piece.position + Vector3.up, (square.position - piece.position).normalized * maxDistance, Color.red);

        List<string> layers = new List<string>();
        layers.Add("White");
        layers.Add("Black");

        if (Physics.Raycast(piece.position + Vector3.up, (square.position - piece.position), out hit, maxDistance, LayerMask.GetMask(layers.ToArray())))
        {
            Debug.Log("GameState: Hey, dude! The path toward the destination is occupied! You can't move over other pieces unless you are a knight! GameState 27");
            return false;

        }
        return true;
    }


    public static bool isValidMove(Transform piece, Transform square) // given piece and square, the function checks if piece can move to the square
    {
        if (!piece || !square) return false; // if there is no piece or no square, move is impossible. This should never happen, but better save then sorry!

        SquareInfo origin = piece.parent.GetComponent<SquareInfo>();
        SquareInfo destination = square.GetComponent<SquareInfo>();

        float maxDistance = Vector3.Distance(square.position, piece.position) - SQUARE_SIZE;

        //float maxDistance = Mathf.Pow((origin.j - destination.j), 2) + Mathf.Pow((origin.i - destination.i),2); // Check the class code for this distance calculation

        Debug.Log(maxDistance);
        if (piece.name.Contains("White")) // validate moves for whites
        {
            if (piece.name.Contains("Pawn"))
            {

                if (((origin.j + 1 == destination.j && origin.i == destination.i) && !destination.piece) ||
                    ((origin.j + 2 == destination.j && origin.i == destination.i) && !destination.piece && origin.j == 1 && isPathEmpty(piece, square, maxDistance)) ||
                    ((origin.j + 1 == destination.j && origin.i + 1 == destination.i) && destination.piece && destination.piece.name.Contains("Black")) ||
                    ((origin.j + 1 == destination.j && origin.i - 1 == destination.i) && destination.piece && (destination.piece.name.Contains("Black"))))
                {
                    return true;
                }
                else return false;
            }


            if (piece.name.Contains("King"))
            {
                if (((origin.i + 1 == destination.i && origin.j == destination.j) ||
                        (origin.i + 1 == destination.i && origin.j + 1 == destination.j) ||
                        (origin.i + 1 == destination.i && origin.j - 1 == destination.j) ||
                        (origin.i - 1 == destination.i && origin.j == destination.j) ||
                        (origin.i - 1 == destination.i && origin.j + 1 == destination.j) ||
                        (origin.i - 1 == destination.i && origin.j - 1 == destination.j) ||
                        (origin.i == destination.i && origin.j + 1 == destination.j) ||
                        (origin.i == destination.i && origin.j - 1 == destination.j))
                    // replace that with conditions 
                    &&
                    (!destination.piece || destination.piece.name.Contains("Black")))
                {
                    return true;
                }
                else return false;
            }

            if (piece.name.Contains("Queen"))
            {
                if (((origin.i == destination.i) && (origin.j != destination.j)) ||
                    ((origin.j == destination.j) && (origin.i != destination.i)) ||
                    ((destination.j - origin.j == destination.i - origin.i)) ||
                    ((origin.j - destination.j == destination.i - origin.i))//This is the condition for Bishop also)
                    &&
                    isPathEmpty(piece, square, maxDistance)
                    &&
                    (!destination.piece || destination.piece.name.Contains("Black")))
                {
                    return true;
                }
                else return false;
            }

            if (piece.name.Contains("Rook"))
            {
                if (((origin.i == destination.i) && (origin.j != destination.j)) ||
                    ((origin.j == destination.j) && (origin.i != destination.i))
                    &&
                    (!destination.piece || destination.piece.name.Contains("Black")))
                {
                    return true;
                }
                else return false;
            }

            if (piece.name.Contains("Bishop"))
            {
                if (((destination.j - origin.j == destination.i - origin.i)) ||
                    ((origin.j - destination.j == destination.i - origin.i))
                    &&
                    (!destination.piece || destination.piece.name.Contains("Black")))
                {
                    return true;
                }
                else return false;
            }

            if (piece.name.Contains("Horse"))
            {
                if (((origin.i - 1 == destination.i && origin.j + 2 == destination.j) ||
                    (origin.i + 1 == destination.i && origin.j + 2 == destination.j) ||
                    (origin.i - 1 == destination.i && origin.j - 2 == destination.j) ||
                    (origin.i + 1 == destination.i && origin.j - 2 == destination.j) ||
                    (origin.i - 2 == destination.i && origin.j - 1 == destination.j) ||
                    (origin.i - 2 == destination.i && origin.j + 1 == destination.j) ||
                    (origin.i + 2 == destination.i && origin.j - 1 == destination.j) ||
                    (origin.i + 2 == destination.i && origin.j + 1 == destination.j))
                    && (!destination.piece || destination.piece.name.Contains("Black")))
                {
                    return true;
                }
                else return false;
            }
        }
        return false;
    }

    void Start()
    {
        for(int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                
                GameObject square = Instantiate(baseCube, boardParent);
                square.GetComponent<SquareInfo>().i = i;
                square.GetComponent<SquareInfo>().j = j;
                square.transform.position = new Vector3(i * SQUARE_SIZE - SQUARE_SIZE * 3.5f, 1.8f, j * SQUARE_SIZE - SQUARE_SIZE * 3.5f);
                

                for (int k = 0; k < chessPiece.childCount; ++k)  //This check squares information
                {
                    if (Vector3.Distance(chessPiece.GetChild(k).position, square.transform.position) < SQUARE_SIZE/2)
                    {
                        square.GetComponent<SquareInfo>().piece = chessPiece.GetChild(k);
                        chessPiece.GetChild(k).parent = square.transform;
                    }
                }
                square.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.0f);
                chessboard[i, j] = square.transform;
            }
        }
        Destroy(baseCube);
/*
        foreach (chessPiece t in allPieces)
        {
            if (t.name.Contains("White"))
            {
                activeWhitePiece.add(piece);
                activeWhitePieceNames.add(t.gameObject.name);       
            }
        }

        string name = activeWhitePiecesNames[Random.Range(0, activeWhitePieces.Count)];

        activeWhitePieces[3].gameObject.name = name;

        activeWhitePiecesNames.remove(name);
        */
    }


    void Update()
    {
        
    }
}