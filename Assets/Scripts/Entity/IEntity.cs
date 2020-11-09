using UnityEngine;
public interface IEntity
{
    void Destroy();
    void SetNewPositionOnCrossingBorder(Vector3 newPosition);
}
