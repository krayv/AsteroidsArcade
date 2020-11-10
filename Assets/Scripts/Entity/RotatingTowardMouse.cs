using UnityEngine;

[RequireComponent(typeof(Player))]
public class RotatingTowardMouse : MonoBehaviour
{
    [SerializeField] private float minAngleDeltaToRotate = 1f;
    private Player player;
    private Camera mainCamera;
    private void Awake()
    {
        player = GetComponent<Player>();
        mainCamera = GameObject.FindGameObjectWithTag(TagsAndLayers.MainCameraTag).GetComponent<Camera>();
    }
    void Update()
    {
        if(StaticVars.controllMode == ControllMode.KeyboardAndMouse)
        {
            
            Vector3 mousePoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetDir = mousePoint - transform.position;
            float angle = Vector3.SignedAngle(targetDir, transform.up, Vector3.forward);
            //float angle = Vector2.SignedAngle(transform.up * -1f, mousePoint);
            if (Mathf.Abs(angle) > minAngleDeltaToRotate)
            {
                player.Rotate(angle < 0f ? 1f : -1f);
            }
        }        
    }
}
