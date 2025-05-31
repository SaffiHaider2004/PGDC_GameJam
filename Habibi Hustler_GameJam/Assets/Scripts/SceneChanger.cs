using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene(0);

    }
    
    public void GamePLay()
    {
        SceneManager.LoadScene(1);

    }
    
    public void EndScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Settings()
    {
        SceneManager.LoadScene(3);
    }

}