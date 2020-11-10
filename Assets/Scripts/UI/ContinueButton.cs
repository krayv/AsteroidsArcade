using UnityEngine.UI;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Button button;   
    private void Start()
    {
        button.gameObject.SetActive(StaticVars.isGameStarted);
    }

    public void OnPlayeDeath()
    {
        button.gameObject.SetActive(false);
    }
}
