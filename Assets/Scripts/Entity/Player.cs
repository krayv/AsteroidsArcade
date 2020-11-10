using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
public class Player : AbstractEntity
{

    public bool isCanBeDestroyed = true;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shotDelay;

    [SerializeField] private float maxSpeed;

    [SerializeField] private float acceleration;

    [SerializeField] private float _rotationSpeed;

    public UnityEvent OnAcceleration;
    public UnityEvent OnShooting;

    public float rotationSpeed
    {
        get { return _rotationSpeed; }
    }

    private InputController inputController;
    private Rigidbody playerRigidbody;
    private float currentDelay;

    public override void Destroy()
    {
        if(!isCanBeDestroyed)
        {
            return;
        }
        inputController.OnPressAccelerationButton.RemoveListener(Accelerate);
        inputController.OnPressHorizontalButton.RemoveListener(Rotate);
        inputController.OnPressShotButton.RemoveListener(Shot);
        base.Destroy();
    }

    private void Awake()
    {
        GameObject gameControllers = GameObject.FindGameObjectWithTag(TagsAndLayers.GameControllerTag);
        inputController = gameControllers.GetComponent<InputController>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        inputController.OnPressAccelerationButton.AddListener(Accelerate);
        inputController.OnPressHorizontalButton.AddListener(Rotate);
        inputController.OnPressShotButton.AddListener(Shot);
    }

    private void Update()
    {
        if(currentDelay > 0f)
        {
            currentDelay -= Time.deltaTime;
        }   
    }

    private void Shot()
    {
        if(currentDelay <= 0f)
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = transform.position;
            newProjectile.transform.rotation = transform.rotation;
            currentDelay = shotDelay;
            OnShooting.Invoke();
        }       
    }

    private void Accelerate()
    {
        float upVelocity = Vector3.Dot(playerRigidbody.velocity, transform.up);
        if (upVelocity < maxSpeed)
        {
            playerRigidbody.AddForce(transform.up * acceleration);
        }
        OnAcceleration.Invoke();
    }
    public void Rotate(float rotateValue)
    {
        playerRigidbody.transform.Rotate(0f, 0f, rotateValue * rotationSpeed * Time.deltaTime);
    }
}
