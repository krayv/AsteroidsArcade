using UnityEngine;

public class NLOProjectile : AbstractProjectile
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.Destroy();
            Destroy();
        }
    }
}
