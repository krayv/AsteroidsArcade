using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private InputController inputController;
    [SerializeField] private GameObject menuObject;

    public void HideMenu()
    {
        Time.timeScale = 1f;
        StaticVars.isGameOnPause = false;
        menuObject.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        StartCoroutine(ShowMenuCorountin());
    }

    public IEnumerator ShowMenuCorountin()
    {
        yield return new WaitForSeconds(1f);
        ShowMenu();
    }

    private void Awake()
    {
        GameObject gameControllers = GameObject.FindGameObjectWithTag(TagsAndLayers.GameControllerTag);
        
        inputController = gameControllers.GetComponent<InputController>();
    }

    private void Start()
    {
        inputController.OnPause.AddListener(ShowMenu);
        if (StaticVars.isGameStarted)
        {
            HideMenu();
        }
        else
        {
            ShowMenu();
        }
        
    }

    private void ShowMenu()
    {
        Time.timeScale = 0f;
        StaticVars.isGameOnPause = true;
        menuObject.SetActive(true);
    }
    
}
