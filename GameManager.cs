using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//using UnityEditor.Search;

public class GameManager : MonoBehaviour
{
    // GM's singleton for easy access throughout the whole project
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    //public GameObject CompleteLevelUI;

    private void Awake()
    {
        // setup singleton 
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void CompleteLevel()
    {
        Debug.Log("Level won");
        //CompleteLevelUI.SetActive(true);
        SceneManager.LoadScene(5);

    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        SceneManager.LoadScene(5);
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
    }
}
