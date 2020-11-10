﻿using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Asteroid : AbstractEntity
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

    public override void Destroy()
    {
        if(sharpAsteroidPrefab != null)
        {
            SpawnAsteroids();
        }
        base.Destroy();
    }

    private void DestroyWithoutSharp()
    {
        base.Destroy();
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
            newAsteroid.transform.rotation =  Quaternion.Euler(0f, 0f, (gameObject.transform.rotation.eulerAngles.z - 45f) + (i * 90f));
        }
        
    }
    
    private float GetRandomSpeedValue()
    {
        return Random.Range(_minSpeed, _maxSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if (player != null)
        {
            player.Destroy();
            DestroyWithoutSharp();
        }
        else
        {
            NLO nlo = collision.transform.GetComponent<NLO>();
            if(nlo != null)
            {
                nlo.Destroy();
                DestroyWithoutSharp();
            }
        }
        
    }

}
