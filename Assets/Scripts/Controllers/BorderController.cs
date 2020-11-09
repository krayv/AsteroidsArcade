using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private float xResolution { get { return Screen.width; } }
    private float yResolution { get { return Screen.height; } }

    [SerializeField] private List<GameObject> gameObjectsForChecking;
    
    public void AddGameObjectForCheck(GameObject gameObject)
    {
        gameObjectsForChecking.Add(gameObject);
    }

    public void RemoveEnityForCheking(GameObject gameObject)
    {
        gameObjectsForChecking.Remove(gameObject);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        foreach(GameObject checkedGameObject in gameObjectsForChecking)
        {
            Vector3 currentPositionOnScreen = mainCamera.WorldToScreenPoint(checkedGameObject.transform.position);
            if(IsCrossedBorder(currentPositionOnScreen.x, xResolution))
            {
                SetNewXPosition(checkedGameObject, currentPositionOnScreen);
                continue;
            }
            if(IsCrossedBorder(currentPositionOnScreen.y, yResolution))
            {
                SetNewYPosition(checkedGameObject, currentPositionOnScreen);
                continue;
            }
        }
    }

    private bool IsCrossedBorder(float gameObjectAxisValue, float borderAxisValue)
    {
        return gameObjectAxisValue < 0f || gameObjectAxisValue > borderAxisValue;
    }
    

    private void SetNewYPosition(GameObject checkedGameObject, Vector3 currentPositionOnScreen)
    {
        Vector3 newPosition;
        if (currentPositionOnScreen.y < 0f)
        {
            newPosition = mainCamera.ScreenToWorldPoint(new Vector3(currentPositionOnScreen.x, yResolution, 0f));            
        }
        else
        {
            newPosition = mainCamera.ScreenToWorldPoint(new Vector3(currentPositionOnScreen.x, 0, 0f));
        }
        newPosition = ClearZPosition(newPosition);
        checkedGameObject.transform.position = newPosition;
    }

    private void SetNewXPosition(GameObject checkedGameObject, Vector3 currentPositionOnScreen)
    {
        Vector3 newPosition;
        if (currentPositionOnScreen.x < 0f)
        {
            newPosition = mainCamera.ScreenToWorldPoint(new Vector3(xResolution, currentPositionOnScreen.y, 0f));
        }
        else
        {
            newPosition = mainCamera.ScreenToWorldPoint(new Vector3(0, currentPositionOnScreen.y, 0f));
        }
        newPosition = ClearZPosition(newPosition);
        checkedGameObject.transform.position = newPosition;
    }

    private Vector3 ClearZPosition(Vector3 position)
    {
        return new Vector3(position.x, position.y, 0f);
    }
}
