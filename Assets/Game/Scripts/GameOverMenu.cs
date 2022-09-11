using UnityEngine;
using UnityEngine.SceneManagement;

// Ha bevan kotve a GameOver screenre es ranyomok a Restart gombra akkor ujrainditja az egesz jatekot

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("MyFirstGame");
    }
}
