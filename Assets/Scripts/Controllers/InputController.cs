using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public UnityEvent OnPause;
    public UnityEvent<float> OnPressHorizontalButton;
    public UnityEvent OnPressAccelerationButton;
    public UnityEvent OnPressShotButton;

    // Update is called once per frame
    private void Update()
    {
        float horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause.Invoke();
        }
        if(Mathf.Abs(horizontalAxisValue) > 0f)
        {
            OnPressHorizontalButton.Invoke(horizontalAxisValue);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            OnPressAccelerationButton.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnPressShotButton.Invoke();
        }
    }
}
