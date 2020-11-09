using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IEntity
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shotDelay;

    [SerializeField] private float maxSpeed;

    [SerializeField] private float acceleration;

    [SerializeField] private float rotationSpeed;

    private InputController inputController;
    private Rigidbody playerRigidbody;
    private float currentDelay;

    public void Destroy()
    {
        Destroy(gameObject);
        inputController.OnPressAccelerationButton.RemoveListener(Accelerate);
        inputController.OnPressHorizontalButton.RemoveListener(Rotate);
        inputController.OnPressShotButton.RemoveListener(Shot);
    }

    public void SetNewPositionOnCrossingBorder(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void Awake()
    {
        GameObject gameControllers = GameObject.FindGameObjectWithTag(TagsAndLayers.GameController);
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
        }       
    }

    private void Accelerate()
    {
        float upVelocity = Vector3.Dot(playerRigidbody.velocity, transform.up);
        if (upVelocity < maxSpeed)
        {
            playerRigidbody.AddForce(transform.up * acceleration);
        }
    }
    private void Rotate(float rotateValue)
    {
        playerRigidbody.transform.Rotate(0f, 0f, rotateValue * rotationSpeed);
    }
}
