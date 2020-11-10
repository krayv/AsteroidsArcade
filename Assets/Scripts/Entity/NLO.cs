using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
public class NLO : AbstractEntity
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float Speed;
    [SerializeField] private float minShotDelay;
    [SerializeField] private float maxShotDelay;

    private Rigidbody currentRigidbody;
    private float currentShotDelay = 0f;
    private Transform player;

    public bool spawnedFromLeftSide;
   
    private void Awake()
    {
        currentRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        float sign = spawnedFromLeftSide ? 1.0f : -1.0f;
        currentRigidbody.AddForce(transform.right * Speed * sign);
        TryGetPlayer();
    }
    private void Update()
    {
        if(currentShotDelay <= 0f)
        {          
            if(player != null)
            {
                currentShotDelay = Random.Range(minShotDelay, maxShotDelay);
                ShotAtPlayer();
            }
            else
            {
                TryGetPlayer();
            }
            
        }
        else
        {
            currentShotDelay -= Time.deltaTime;
        }
    }
    private void ShotAtPlayer()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = gameObject.transform.position;
        projectile.transform.rotation = Quaternion.Euler(0, 0, StaticMethods.GetAngleBetweenPoint(transform.position, player.transform.position));
    }  
    private void TryGetPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(TagsAndLayers.PlayerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if (player != null)
        {
            player.Destroy();
            Destroy();
        }

    }
}
