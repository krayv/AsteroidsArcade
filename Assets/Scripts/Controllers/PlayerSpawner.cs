using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 defaultSpawnPosition;
    [SerializeField] private int _LifeCount = 3;
    public int LifeCount
    {
        get 
        { 
            return _LifeCount; 
        }
        set
        {
            _LifeCount = value;
            lifeValueChanged.Invoke(_LifeCount);
        }
    }
    [SerializeField] GameObject playerPrefab;

    public UnityEvent<int> lifeValueChanged;
    public UnityEvent playerFinalyDead;

    private void Start()
    {
        if(StaticVars.isGameStarted)
        {
            SpawnPlayer();
        }     
    }


    private void OnDeath(GameObject player)
    {
        if (LifeCount > 0)
        {
            SpawnPlayer();
            LifeCount = LifeCount - 1;
        }
        else
        {
            playerFinalyDead.Invoke();
        }
    }

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = defaultSpawnPosition;
        AbstractEntity entity = player.GetComponent<Player>();
        entity.onDestroy.AddListener(OnDeath);
    }
}
