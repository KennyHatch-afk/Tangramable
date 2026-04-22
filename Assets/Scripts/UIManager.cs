using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField]
    private Dictionary<string, GameObject> UIPrefabs = new Dictionary<string, GameObject>();

    public List<GameObject> prefabs = new List<GameObject>();

    private string currentUIName;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        foreach(GameObject p in prefabs)
        {
            Debug.Log(p.name);
            UIPrefabs.Add(p.name, p);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUI(string name)
    {
        currentUIName = name;
        Activate();
    }

    private void Activate()
    {
        instance.UIPrefabs[currentUIName].SetActive(true);
    }

    public void ClearScreen()
    {
        UIPrefabs[currentUIName].SetActive(false);
    }

}
