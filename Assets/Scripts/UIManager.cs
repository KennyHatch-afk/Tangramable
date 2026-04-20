using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField]
    private GameObject gameOverScreen;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        instance.gameOverScreen.SetActive(true);
    }

    public void clearScreen()
    {
        gameOverScreen.SetActive(false);
    }

}
