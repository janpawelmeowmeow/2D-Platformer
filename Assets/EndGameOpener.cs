using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameOpener : MonoBehaviour
{
    public void OpenScene(string EndGame)
    {
        SceneManager.LoadScene(EndGame);


    }
}
