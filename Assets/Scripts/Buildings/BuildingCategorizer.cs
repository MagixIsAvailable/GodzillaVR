using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BuildingCategorizer : MonoBehaviour
{
    public enum BuildingSize { Small, Medium, Large }
    public BuildingSize buildingSize;

    void Start()
    {
        CategorizeBuilding();
    }

    public void CategorizeBuilding()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null) return;

        Bounds bounds = renderer.bounds;
        float volume = bounds.size.x * bounds.size.y * bounds.size.z;
        float height = bounds.size.y;

        if (volume < 10000)
            buildingSize = BuildingSize.Small;
        else if (volume < 150000)
            buildingSize = BuildingSize.Medium;
        else
            buildingSize = BuildingSize.Large;


        // Set tag or layer depending on size
        switch (buildingSize)
        {
            case BuildingSize.Small:
                gameObject.tag = "SmallBuilding";
                break;
            case BuildingSize.Medium:
                gameObject.tag = "MediumBuilding";
                break;
            case BuildingSize.Large:
                gameObject.tag = "LargeBuilding";
                break;
        }

#if UNITY_EDITOR
        EditorUtility.SetDirty(gameObject); // Marks modified for saving in editor
#endif

        Debug.Log($"{gameObject.name} categorized as {buildingSize} (Volume: {volume}, Height: {height})");
    }
}
