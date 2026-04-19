using System;
using System.Collections.Generic;
using TMPro;
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
    }

    void Update()
    {
        if (!Mouse.current.leftButton.isPressed)
        {
            gameWon = CheckForWin();
        }
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
            if (piece == null) continue;

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
        SpawnSihlouette();
        FindPieces();
        SetSolutions();
        levelText.GetComponent<TextMeshProUGUI>().text = "Level " + counter + ": " + currentLevelData.levelName;
        //Debug.Log(currentLevel);
    }

    public void FindPieces()
    {
        currentPieces = new List<Piece>(currentLevel.GetComponentsInChildren<Piece>());
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
        currentSilhouette.transform.position = new Vector3(currentSilhouette.transform.position.x, currentSilhouette.transform.position.y, 1f);
    }

}
