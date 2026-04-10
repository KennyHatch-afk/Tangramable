using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public LevelData currentLevelData;
    private int counter = 1;

    public List<Piece> currentPieces;

    public bool gameWon = false;

    public GameObject levelText;

    private Dictionary<string, GameObject> levelPrefabs = new Dictionary<string, GameObject>();

    public List<GameObject> prefabs = new List<GameObject>();

    private Dictionary<string, GameObject> levelSilhouettes = new Dictionary<string, GameObject>();

    public List<GameObject> silhouettes = new List<GameObject>();

    private GameObject currentLevel;
    private GameObject currentSilhouette;

    void Start()
    {

        foreach (GameObject p in prefabs)
        {
            levelPrefabs.Add(p.name, p);
        }

        foreach (GameObject s in silhouettes)
        {
            levelSilhouettes.Add(s.name, s);
        }
        LoadLevel("level_" + counter);
        levelText.GetComponent<TextMeshProUGUI>().text = "Level 1: " + currentLevelData.levelName;
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
        currentLevelData = Resources.Load<LevelData>("Levels/" + levelName);
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
    if (currentLevel != null)
    {
        Destroy(currentLevel);
    }

    currentLevel = Instantiate(levelPrefabs["Level_" + counter]);
}

    public void SetSolutions()
    {
        foreach (Piece p in currentPieces)
        {
            p.SetTarget(currentLevelData.positionSolution[p.id], currentLevelData.rotationSolution[p.id]);
        }
    }

    public void SpawnSihlouette()
    {
        if (currentSilhouette != null)
        {
            Destroy(currentSilhouette);
        }

        currentSilhouette = Instantiate(
            levelSilhouettes["level_" + counter + "_Soln"]
        );
    }

}
