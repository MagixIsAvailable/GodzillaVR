using UnityEngine;

public class DestructionSpawner : MonoBehaviour
{
    public GameObject debrisPrefab;
    public int debrisCount = 10;
    public float spawnRadius = 5f;
    public float explosionForce = 300f;

    public void SpawnDebris()
    {
        if (debrisPrefab == null)
        {
            Debug.LogWarning("Debris Prefab not set!");
            return;
        }

        for (int i = 0; i < debrisCount; i++)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject debris = Instantiate(debrisPrefab, randomPos, Random.rotation);

            Rigidbody rb = debris.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, spawnRadius);
            }

            Destroy(debris, 5f); // Auto destroy debris after 5 seconds
        }
    }
}
