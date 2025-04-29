using UnityEngine;

[ExecuteAlways]
public class BuildingVisualizer : MonoBehaviour
{
    private BuildingCategorizer categorizer;
    private Renderer renderer;

    private void OnDrawGizmos()
    {
        if (categorizer == null)
            categorizer = GetComponent<BuildingCategorizer>();
        if (renderer == null)
            renderer = GetComponent<Renderer>();
        if (categorizer == null || renderer == null) return;

        Color color = Color.white;

        switch (categorizer.buildingSize)
        {
            case BuildingCategorizer.BuildingSize.Small:
                color = Color.green;
                break;
            case BuildingCategorizer.BuildingSize.Medium:
                color = Color.yellow;
                break;
            case BuildingCategorizer.BuildingSize.Large:
                color = Color.red;
                break;
        }

        Gizmos.color = color;
        Gizmos.DrawWireCube(renderer.bounds.center, renderer.bounds.size);
    }
}
