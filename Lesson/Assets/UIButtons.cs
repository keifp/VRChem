using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{

    public void Test()
    {

    }
    //getting button click and looking for current LevelInfo sript in the scene. This is because I can't plug it in the scene directly since the script comes from another scene
    public void QuitGameBtn()
    {
        FindObjectOfType<LevelInfo>().QuitGame();
    }
    public void RestartBtn()
    {
        FindObjectOfType<LevelInfo>().Restart();

    }

    public void NextLevelBtn()
    {

        FindObjectOfType<LevelInfo>().NextLevel();
    }
}
