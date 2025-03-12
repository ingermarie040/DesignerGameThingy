using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float startSpeed = 2;
    [SerializeField] private InputActionProperty inputAction;

    private void Start() { }

    void Update()
    {
        if (inputAction.action.WasPressedThisFrame())
        {
            Debug.Log("DETECTED: Cube Spawn button click");
            CreateCube();
        }
    }

    void CreateCube()
    {
        GameObject spawnedCub = Instantiate(cubePrefab, transform.position, transform.rotation);
        Rigidbody cubeRigidbody = spawnedCub.GetComponent<Rigidbody>();
        cubeRigidbody.linearVelocity = transform.forward * startSpeed;
        Debug.Log("CUBESPAWN: Cube Spawned");
    }
}
