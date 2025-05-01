using UnityEngine;
using UnityEditor;

public class BuildingCategorizerEditor : EditorWindow
{
    [MenuItem("Tools/Building Categorizer")]
    public static void ShowWindow()
    {
        GetWindow<BuildingCategorizerEditor>("Building Categorizer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Building Categorization", EditorStyles.boldLabel);

        if (GUILayout.Button("Categorize Selected Buildings"))
        {
            CategorizeSelectedBuildings();
        }
    }

    private void CategorizeSelectedBuildings()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            BuildingCategorizer categorizer = obj.GetComponent<BuildingCategorizer>();
            if (categorizer != null)
            {
                categorizer.CategorizeBuilding();
                EditorUtility.SetDirty(obj); // Mark modified
            }
        }
        Debug.Log("Selected buildings categorized!");
    }
}
