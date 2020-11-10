using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public UnityEvent OnPause;
    public UnityEvent<float> OnPressHorizontalButton;
    public UnityEvent OnPressAccelerationButton;
    public UnityEvent OnPressShotButton;

    private void Update()
    {
        float horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        if(!StaticVars.isGameOnPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPause.Invoke();
            }
            if (CheckRotatesButtons(horizontalAxisValue))
            {
                OnPressHorizontalButton.Invoke(horizontalAxisValue);
            }
            if (CheckAccelerationsButton())
            {
                OnPressAccelerationButton.Invoke();
            }
            if (CheckShotButton())
            {
                OnPressShotButton.Invoke();
            }
        }       
    }

    private bool CheckRotatesButtons(float horizontalAxisValue)
    {
        if(StaticVars.controllMode == ControllMode.Keyboard)
        {
            return Mathf.Abs(horizontalAxisValue) > 0f;
        }
        else
        {
            return false;
        }
    }
    private bool CheckAccelerationsButton()
    {
        if (StaticVars.controllMode == ControllMode.Keyboard)
        {
            return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        }
        else
        {
            return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButton(1);
        }
    }
    private bool CheckShotButton()
    {
        if (StaticVars.controllMode == ControllMode.Keyboard)
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
        else
        {
            return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        }
    }
}
