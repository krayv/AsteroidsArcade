using UnityEngine;

public class NLOSpanwer : MonoBehaviour
{
    [SerializeField] float maxSpawnDelay;
    [SerializeField] float minSpawnDelay;
    [SerializeField] GameObject NLOPrefab;
    [SerializeField] float minYSpawnPosition = 0.2f;
    [SerializeField] float maxYSpawnPosition = 0.8f;


    private float currentSpawnDelay;
    private Camera mainCamera;
    private GameObject currentNLO;

    private void Start()
    {
        GetSpawnDelay();
        GameObject camera = GameObject.FindGameObjectWithTag(TagsAndLayers.MainCameraTag);
        if(camera != null)
        {
            mainCamera = camera.GetComponent<Camera>();
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        if(StaticVars.isGameStarted)
        {
            if (currentNLO == null)
            {
                if (currentSpawnDelay <= 0f)
                {
                    GameObject nlo = Instantiate(NLOPrefab);
                    currentNLO = nlo;
                    AbstractEntity abstractEntity = nlo.GetComponent<AbstractEntity>();
                    abstractEntity.onDestroy.AddListener(OnDestroyNLO);
                    SetPosition(nlo);
                    GetSpawnDelay();
                }
                else
                {
                    currentSpawnDelay -= Time.deltaTime;
                }
            }
        }     
    }

    private void GetSpawnDelay()
    {
        currentSpawnDelay = Random.Range(maxSpawnDelay, minSpawnDelay);
    }


    private void SetPosition(GameObject nlo)
    {
        float yPosition = Random.Range(Screen.height * minYSpawnPosition, Screen.height * maxYSpawnPosition);
        float xPosition;
        NLO nloComponent = nlo.GetComponent<NLO>();
        if(Random.Range(0, 2) == 0)
        {
            xPosition = 0;
            nloComponent.spawnedFromLeftSide = true;
        }
        else
        {
            xPosition = Screen.width;
            nloComponent.spawnedFromLeftSide = false;
        }
        Vector3 position = new Vector3(xPosition, yPosition, 0);
        nlo.transform.position = StaticMethods.ClearZPosition(mainCamera.ScreenToWorldPoint(position));
    }

    private void OnDestroyNLO(GameObject nlo)
    {
        if(nlo == currentNLO)
        {
            currentNLO = null;
        }      
    }
}
