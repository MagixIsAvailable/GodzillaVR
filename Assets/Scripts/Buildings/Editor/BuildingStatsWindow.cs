using UnityEngine;
using UnityEditor;

public class BuildingStatsWindow : EditorWindow
{
    [MenuItem("Tools/Building Stats")]
    public static void ShowWindow()
    {
        GetWindow<BuildingStatsWindow>("Building Stats");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Refresh Building Stats"))
        {
            RefreshStats();
        }

        GUILayout.Label($"Small Buildings: {smallCount}");
        GUILayout.Label($"Medium Buildings: {mediumCount}");
        GUILayout.Label($"Large Buildings: {largeCount}");
    }

    int smallCount, mediumCount, largeCount;

    void RefreshStats()
    {
        BuildingCategorizer[] allBuildings = FindObjectsOfType<BuildingCategorizer>();

        smallCount = 0;
        mediumCount = 0;
        largeCount = 0;

        foreach (var building in allBuildings)
        {
            switch (building.buildingSize)
            {
                case BuildingCategorizer.BuildingSize.Small:
                    smallCount++;
                    break;
                case BuildingCategorizer.BuildingSize.Medium:
                    mediumCount++;
                    break;
                case BuildingCategorizer.BuildingSize.Large:
                    largeCount++;
                    break;
            }
        }

        Debug.Log("Building stats refreshed.");
    }
}
