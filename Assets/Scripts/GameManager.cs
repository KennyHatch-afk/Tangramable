using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public LevelData currentLevel;
    private int counter = 1;

    public List<Piece> currentPieces;

    public bool gameWon = false;

    public GameObject levelText;

    private Dictionary<string, GameObject> levelPrefabs = new Dictionary<string, GameObject>();

    public List<GameObject> prefabs = new List<GameObject>();

    private Dictionary<string, GameObject> levelSihlouettes = new Dictionary<string, GameObject>();

    public List<GameObject> sihlouettes = new List<GameObject>();

    void Start()
    {

        foreach (GameObject p in prefabs)
        {
            levelPrefabs.Add(p.name, p);
        }

        foreach (GameObject s in sihlouettes)
        {
            levelSihlouettes.Add(s.name, s);
        }
        LoadLevel("level_" + counter);
        levelText.GetComponent<TextMeshProUGUI>().text = "Level 1: " + currentLevel.levelName;
    }

    void Update()
    {
        gameWon = CheckForWin();
        if (gameWon)
        {
            counter++;
            LoadLevel("level_" + counter);
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
        Debug.Log("called load level");
        currentLevel = Resources.Load<LevelData>("Levels/" + levelName);
        gameWon = false;
        SpawnPieces();
        FindPieces();
        SetSolutions();
        SpawnSihlouette();
        //Debug.Log(currentLevel);
    }

    public void FindPieces()
    {
        currentPieces = new List<Piece>(FindObjectsByType<Piece>(FindObjectsSortMode.None));
    }

    public void SpawnPieces()
    {
        if (counter > 1)
            Destroy(levelPrefabs["Level_" + (counter - 1)]);
        Instantiate(levelPrefabs["Level_" + counter]);
    }

    public void SetSolutions()
    {
        foreach (Piece p in currentPieces)
        {
            p.SetTarget(currentLevel.positionSolution[p.id], currentLevel.rotationSolution[p.id]);
        }
    }

    public void SpawnSihlouette()
    {
        if (counter > 1)
            Destroy(levelSihlouettes["level_" + (counter - 1) + "_Soln"]);
        Instantiate(levelSihlouettes["level_" + counter + "_Soln"]);
    }

}
