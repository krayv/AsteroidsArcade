using UnityEngine;
using UnityEngine.SceneManagement;
public class StarterController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.SampleScene);
        StaticVars.isGameStarted = true;
    }
}
