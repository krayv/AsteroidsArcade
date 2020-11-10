using UnityEngine;
using UnityEngine.Events;
public abstract class AbstractEntity: MonoBehaviour
{
    public UnityEvent<GameObject> onDestroy;

    public virtual void Destroy()
    {
        onDestroy.Invoke(gameObject);
        Destroy(gameObject);
        onDestroy.RemoveAllListeners();
    }
    public virtual void SetNewPositionOnCrossingBorder(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
