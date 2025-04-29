using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    private Rigidbody rb;
    private bool isActive = false;
    private bool isDestroyed = false;
    public float activationDistance = 80f;
    private Transform godzillaTransform;
    private BuildingCategorizer buildingCategorizer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = true;
        godzillaTransform = GameObject.FindGameObjectWithTag("Player").transform;
        buildingCategorizer = GetComponent<BuildingCategorizer>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, godzillaTransform.position);

        if (distance < activationDistance && !isActive)
            ActivateBuilding();
        else if (distance > activationDistance && isActive)
            DeactivateBuilding();
    }

    void ActivateBuilding()
    {
        isActive = true;
        if (rb) rb.isKinematic = false;
    }

    void DeactivateBuilding()
    {
        isActive = false;
        if (rb) rb.isKinematic = true;
    }

    public void GrabBuilding()
    {
        if (!isActive || isDestroyed) return;

        if (buildingCategorizer != null)
        {
            switch (buildingCategorizer.buildingSize)
            {
                case BuildingCategorizer.BuildingSize.Small:
                    Debug.Log("Small building grabbed easily!");
                    rb.isKinematic = true;
                    transform.SetParent(godzillaTransform);
                    break;
                case BuildingCategorizer.BuildingSize.Medium:
                    Debug.Log("Medium building grabbed with effort!");
                    rb.mass = 20f; // heavier
                    rb.drag = 5f;  // more resistance
                    rb.isKinematic = false;
                    break;
                case BuildingCategorizer.BuildingSize.Large:
                    Debug.Log("Large building too big to grab!");
                    // Maybe Godzilla cannot grab large ones
                    break;
            }
        }
    }

    public void DestroyBuilding()
    {
        if (!isActive || isDestroyed) return;

        DestructionSpawner spawner = GetComponent<DestructionSpawner>();
        if (spawner != null)
        {
            spawner.SpawnDebris();
        }

        if (buildingCategorizer != null)
        {
            switch (buildingCategorizer.buildingSize)
            {
                case BuildingCategorizer.BuildingSize.Small:
                    Destroy(gameObject);
                    break;
                case BuildingCategorizer.BuildingSize.Medium:
                    StartCoroutine(DestroyAfterDelay(0.5f));
                    break;
                case BuildingCategorizer.BuildingSize.Large:
                    StartCoroutine(DestroyAfterDelay(2f));
                    break;
            }
        }

        isDestroyed = true;
    }

    private System.Collections.IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
