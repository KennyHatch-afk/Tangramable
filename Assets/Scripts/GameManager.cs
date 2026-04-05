using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelData currentLevel;

    public List<Piece> currentPieces;

    public bool gameWon = false;

    void Start()
    {
        currentPieces = new List<Piece>(FindObjectsByType<Piece>(FindObjectsSortMode.None));
        LoadLevel("level_1");
    }

    void Update()
    {
        gameWon = CheckForWin();
        if(gameWon)
        {
            LoadLevel("level_2");
        }
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

    public void LoadLevel(string levelName)
    {
        currentLevel = Resources.Load<LevelData>("Levels/" + levelName);
        gameWon = false;
        SetSolutions();
        Debug.Log(currentLevel);
    }

    public void SetSolutions()
    {
        foreach(Piece p in currentPieces)
        {
            p.SetTarget(currentLevel.positionSolution[p.id], currentLevel.rotationSolution[p.id]);
        }
    }

}
