using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class AbstractProjectile : MonoBehaviour, IEntity
{

    [SerializeField] float _Speed;

    private Rigidbody currentRigidbody;

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetNewPositionOnCrossingBorder(Vector3 newPosition)
    {
        Destroy();
    }

    private void Awake()
    {
        currentRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentRigidbody.velocity = transform.up * _Speed;
    }
}
