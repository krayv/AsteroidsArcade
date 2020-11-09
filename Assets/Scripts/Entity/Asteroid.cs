using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Asteroid : MonoBehaviour, IEntity
{
    [SerializeField] private GameObject sharpAsteroidPrefab;

    [SerializeField] private float _sharpCount;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;

    private float _Speed;

    public float Speed { 
        get 
        { 
            return _Speed; 
        } 
        set 
        {
            IsSpeedSeted = true;
            _Speed = value; 
        } 
    }

    private Rigidbody currentRigidbody;
    private bool IsSpeedSeted;

    public void Destroy()
    {
        if(sharpAsteroidPrefab != null)
        {
            SpawnAsteroids();
        }
        Destroy(gameObject);
    }

    public void SetNewPositionOnCrossingBorder(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void Awake()
    {
        currentRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if(!IsSpeedSeted)
        {
            Speed = GetRandomSpeedValue();
        }
        currentRigidbody.AddForce(transform.up * Speed);
    }

    private void SpawnAsteroids()
    {
        float newSpeed = GetRandomSpeedValue();
        for (int i = 0; i < _sharpCount; i++)
        {
            GameObject newAsteroid = Instantiate(sharpAsteroidPrefab);
            Asteroid asteroid = newAsteroid.GetComponent<Asteroid>();
            asteroid.Speed = newSpeed;
            newAsteroid.transform.position = gameObject.transform.position;
            newAsteroid.transform.rotation =  Quaternion.Euler(0f, 0f, (gameObject.transform.rotation.z - 45f) + (i * 90f));
        }
        
    }
    
    private float GetRandomSpeedValue()
    {
        return Random.Range(_minSpeed, _maxSpeed);
    }
 
}
