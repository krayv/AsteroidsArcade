using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class AbstractProjectile : AbstractEntity
{

    [SerializeField] float _Speed;

    private Rigidbody currentRigidbody;

    public override void SetNewPositionOnCrossingBorder(Vector3 newPosition)
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
