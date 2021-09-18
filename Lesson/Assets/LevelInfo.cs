using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void YouWon()
    {
        print("you won");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        currentLevel = 0;
        SceneManager.LoadScene(0);
    }    

    public void NextLevel()
    {

        SceneManager.LoadScene(0);
    }
}
