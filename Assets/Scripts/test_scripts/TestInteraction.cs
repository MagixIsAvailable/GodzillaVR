using UnityEngine;

public class TestInteraction : MonoBehaviour
{
    public float destroyDelay = 2f; // Time before destroying
    public bool destroyInsteadOfGrab = true;

    private BuildingInteraction buildingInteraction;

    void Start()
    {
        buildingInteraction = GetComponent<BuildingInteraction>();

        if (buildingInteraction != null)
        {
            if (destroyInsteadOfGrab)
                Invoke(nameof(DestroyBuilding), destroyDelay);
            else
                Invoke(nameof(GrabBuilding), destroyDelay);
        }
    }

    void DestroyBuilding()
    {
        buildingInteraction.DestroyBuilding();
    }

    void GrabBuilding()
    {
        buildingInteraction.GrabBuilding();
    }
}
