using UnityEngine;

public static class StaticMethods 
{
    public static Vector3 ClearZPosition(Vector3 position)
    {
        return new Vector3(position.x, position.y, 0);
    }

    public static float GetAngleBetweenPoint(Vector3 from, Vector3 to)
    {
        Vector2 difference = to - from;
        float sign = (to.y < from.y) ? -1.0f : 1.0f;
        float angle = Vector2.Angle(Vector3.right, difference) * sign;
        return angle - 90f;
    }
    public static float GetRandomSign()
    {
        return Random.Range(0, 2) == 0 ? -1.0f : 1.0f; 
    }
}
