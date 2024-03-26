using UnityEngine;

public class MysteryShip : MonoBehaviour
{
    public float appearanceIntervalMin = 30f;
    public float appearanceIntervalMax = 50f;
    public float movementSpeed = 5f;
    public float spawnHeight = 10f;
    public float despawnX = 10f;

    private float nextAppearanceTime;

    private void Start()
    {
        SetNextAppearanceTime();
    }

    private void Update()
    {
        if (Time.time > nextAppearanceTime)
        {
            SpawnMysteryShip();
            SetNextAppearanceTime();
        }
    }

    private void SpawnMysteryShip()
    {
        transform.position = new Vector3(-10f, spawnHeight, 0f); // Spawn at top-left corner
        gameObject.SetActive(true);
    }

    private void SetNextAppearanceTime()
    {
        nextAppearanceTime = Time.time + Random.Range(appearanceIntervalMin, appearanceIntervalMax);
    }

    private void FixedUpdate()
    {
        MoveMysteryShip();
    }

    private void MoveMysteryShip()
    {
        transform.position += Vector3.right * movementSpeed * Time.fixedDeltaTime;

        // Check if MysteryShip reached the despawn position
        if (transform.position.x >= despawnX)
        {
            gameObject.SetActive(false);
        }
    }
}