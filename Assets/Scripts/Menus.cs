using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menus : MonoBehaviour
{
    public List<GameObject> disabledObjects;
    public List<GameObject> startObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in disabledObjects)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        foreach (GameObject obj in disabledObjects)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in startObjects)
        {
            obj.SetActive(false);
        }
    }

    public void LevelChange()
    {
        foreach(GameObject obj in disabledObjects)
        {
            obj.SetActive(false);
        }
    }
}
