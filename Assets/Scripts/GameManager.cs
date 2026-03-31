using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Piece> currentPieces;

    public bool gameWon = false;

    void Start()
    {
        currentPieces = new List<Piece>(FindObjectsByType<Piece>(FindObjectsSortMode.None));
    }

    void Update()
    {
        gameWon = CheckForWin();
    }

    bool CheckForWin()
    {
        int numCorrect = 0;

        foreach (Piece piece in currentPieces)
        {
            if (piece.isCorrect())
            {
                numCorrect++;
            }
        }

        return numCorrect == currentPieces.Count;
    }



}
