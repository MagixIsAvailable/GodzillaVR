using UnityEngine;

public class GiantController : MonoBehaviour
{
    public float interactDistance = 10f;
    public KeyCode grabKey = KeyCode.E;
    public KeyCode destroyKey = KeyCode.F;

    void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            TryGrabBuilding();
        }
        if (Input.GetKeyDown(destroyKey))
        {
            TryDestroyBuilding();
        }
    }

    void TryGrabBuilding()
    {
        BuildingInteraction building = FindClosestBuilding();
        if (building != null)
        {
            building.GrabBuilding();
        }
    }

    void TryDestroyBuilding()
    {
        BuildingInteraction building = FindClosestBuilding();
        if (building != null)
        {
            building.DestroyBuilding();
        }
    }

    BuildingInteraction FindClosestBuilding()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactDistance);
        foreach (Collider hit in hits)
        {
            BuildingInteraction building = hit.GetComponent<BuildingInteraction>();
            if (building != null)
            {
                return building;
            }
        }
        return null;
    }
}
