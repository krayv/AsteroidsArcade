using System.Collections;
using System.Collections.Generic;
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
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
