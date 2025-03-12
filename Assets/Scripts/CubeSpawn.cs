using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject spherePrefab;
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
        // Randomly decide between spawning a cube or a sphere
        GameObject prefabToSpawn = Random.value > 0.5f ? cubePrefab : spherePrefab;
        GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation);

        // Assign a pastel color
        Renderer renderer = spawnedObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = GetRandomPastelColor();
        }

        // Apply velocity
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * startSpeed;
        }

        Debug.Log("SPAWN: Object spawned with color " + renderer.material.color);
    }

    Color GetRandomPastelColor()
    {
        float r = Random.Range(0.5f, 1f);
        float g = Random.Range(0.5f, 1f);
        float b = Random.Range(0.5f, 1f);
        return new Color(r, g, b);
    }
}
