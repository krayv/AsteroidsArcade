using UnityEngine;
using UnityEngine.UI;
public class ControllModeButton : MonoBehaviour
{
    [SerializeField] Text text;

    public void SwitchMode()
    {
        if (StaticVars.controllMode == ControllMode.Keyboard)
        {
            StaticVars.controllMode = ControllMode.KeyboardAndMouse;
        }
        else
        {
            StaticVars.controllMode = ControllMode.Keyboard;
        }
        SetText();
    }
    private void Start()
    {
        SetText();
    }

    private void SetText()
    {
        if (StaticVars.controllMode == ControllMode.Keyboard)
        {
            text.text = "Управление: клавиатура";
        }
        else
        {
            text.text = "Управление: клавиатура + мышь";
        }
    }
}
