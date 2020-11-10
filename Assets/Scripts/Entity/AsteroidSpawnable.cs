using UnityEngine;

public class AsteroidSpawnable : Spawneble
{
    private AsteroidSpawner asteroidSpawner;
    protected override void Awake()
    {
        base.Awake();
        asteroidSpawner = controller.GetComponent<AsteroidSpawner>();
    }


    protected override void OnSpawn()
    {
        base.OnSpawn();
        asteroidSpawner.AddAsteroid(gameObject);
    }
}
