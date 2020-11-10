using UnityEngine;

public class PlayerProjectile : AbstractProjectile
{
    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();
        if(asteroid != null)
        {
            asteroid.Destroy();
            Destroy();
        }
        else
        {
            NLO nlo = other.GetComponent<NLO>();
            if (nlo != null)
            {
                nlo.Destroy();
                Destroy();
            }
        }    
    }
}
