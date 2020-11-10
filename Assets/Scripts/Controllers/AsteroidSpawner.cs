using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float minimalSpawnRangeForPlayer;

    private List<GameObject> spawnedAsteroids = new List<GameObject>();
    private int iteration = 0;
    private Camera mainCamera;

    public void AddAsteroid(GameObject asteroid)
    {
        spawnedAsteroids.Add(asteroid);
        AbstractEntity entity = asteroid.GetComponent<AbstractEntity>();
        entity.onDestroy.AddListener(RemoveAsteroid);
    }
    public void RemoveAsteroid(GameObject asteroid)
    {
        spawnedAsteroids.Remove(asteroid);
        if(spawnedAsteroids.Count == 0)
        {
            StartCoroutine(StartTrySpawnAsteroirds());
        }
    }

    private IEnumerator StartTrySpawnAsteroirds()
    {
        yield return new WaitForSeconds(spawnDelay);
        if (spawnedAsteroids.Count == 0)
        {
            ++iteration;
            SpawnAsteroids();
        }
            
    }

    private void Start()
    {
        if(StaticVars.isGameStarted)
        {
            mainCamera = GameObject.FindGameObjectWithTag(TagsAndLayers.MainCameraTag).GetComponent<Camera>();
            SpawnAsteroids();
        }
        
    }
    
    private void SpawnAsteroids()
    {
        for(int i = 0; i <= iteration + 1; i++)
        {
            GameObject asteroid = Instantiate(asteroidPrefab);
            asteroid.transform.position = GetPosition();
            asteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            AddAsteroid(asteroid);
        }
    }
    private Vector3 GetPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag(TagsAndLayers.PlayerTag);
        Vector3 newPosition = GetRandomPointOnScreen();
        if (player != null)
        {
            while((player.transform.position - newPosition).magnitude < minimalSpawnRangeForPlayer)
            {
                newPosition = GetRandomPointOnScreen();
            }
            return newPosition;
        }
        return newPosition;

    }
    private Vector3 GetRandomPointOnScreen()
    {
        Vector3 point =  new Vector3(Random.Range(0, Screen.width), Random.Range(0,Screen.height), 0);
        return StaticMethods.ClearZPosition(mainCamera.ScreenToWorldPoint(point));
    }

}
