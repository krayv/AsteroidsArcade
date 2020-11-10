using UnityEngine;

[RequireComponent (typeof(AbstractEntity))]
public class Spawneble : MonoBehaviour
{

    protected GameObject controller;
    protected BorderController borderController;
    protected virtual void Awake()
    {
        controller = GameObject.FindGameObjectWithTag(TagsAndLayers.GameControllerTag);
        borderController = controller.GetComponent<BorderController>();
    }

    protected virtual void Start()
    {
        OnSpawn();
    }

    protected virtual void OnSpawn()
    {
        borderController.AddGameObjectForCheck(gameObject, gameObject.GetComponent<AbstractEntity>());
    }
}
