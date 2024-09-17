using UnityEditor;
using CustomAttributes;
using UnityEngine;

[CustomPropertyDrawer(typeof(CategoryAttribute))]
public class CategoryDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        CategoryAttribute category = (CategoryAttribute)attribute;

        // Styling
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.alignment = category.textAnchor;
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 15;

        // Draw the category label
        EditorGUI.LabelField(position, category.label, style);
    }

    // Adjust the categry label according to the other elements
    public override float GetHeight()
    {
        return EditorGUIUtility.singleLineHeight + 10;
    }


}
