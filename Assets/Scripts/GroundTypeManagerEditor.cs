using UnityEditor;

using UnityEditorInternal;

//Tells the Editor class that this will be the Editor for the WaveManager
[CustomEditor(typeof(GroundTypeManager))]
public class GroundTypeManagerEditor : Editor
{
    //The array property we will edit
    SerializedProperty groundType;

    //The Reorderable list we will be working with
    ReorderableList list;

    private void OnEnable()
    {
        //Gets the wave property in WaveManager so we can access it. 
        groundType = serializedObject.FindProperty("groundType");

        //Initialises the ReorderableList. We are creating a Reorderable List from the "wave" property. 
        //In this, we want a ReorderableList that is draggable, with a display header, with add and remove buttons        
        list = new ReorderableList(serializedObject, groundType, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;

    }

    void DrawListItems(UnityEngine.Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); //The element in the list

        // Create a property field and label field for each property. 

        // The 'mobs' property. Since the enum is self-evident, I am not making a label field for it. 
        // The property field for mobs (width 100, height of a single line)
        EditorGUI.PropertyField(
            new UnityEngine.Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("groundType"),
            UnityEngine.GUIContent.none
        );

        // The 'level' property
        // The label field for level (width 100, height of a single line)
        EditorGUI.LabelField(new UnityEngine.Rect(rect.x + 120, rect.y, 120, EditorGUIUtility.singleLineHeight), "Friction");

        //The property field for level. Since we do not need so much space in an int, width is set to 20, height of a single line.
        EditorGUI.PropertyField(
            new UnityEngine.Rect(rect.x + 180, rect.y, 35, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("Friction"),
            UnityEngine.GUIContent.none
        );

        EditorGUI.LabelField(new UnityEngine.Rect(rect.x + 250, rect.y, 120, EditorGUIUtility.singleLineHeight), "Max Speed");

        //The property field for level. Since we do not need so much space in an int, width is set to 20, height of a single line.
        EditorGUI.PropertyField(
            new UnityEngine.Rect(rect.x + 325, rect.y, 35, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("MaxVelocity"),
            UnityEngine.GUIContent.none
        );
    }

    void DrawHeader(UnityEngine.Rect rect)
    {
        string name = "GroundType";
        EditorGUI.LabelField(rect, name);
    }

    //This is the function that makes the custom editor work
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }
}