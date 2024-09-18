using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using CustomAttributes;


#if UNITY_EDITOR



[CustomPropertyDrawer(typeof(CustomAttributes.Map<,>))]
public class SerializableDictionaryDrawer : PropertyDrawer
{
    private const float lineHeight = 18f;
    private const float spacing = 2f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var keys = property.FindPropertyRelative("keys");
        var values = property.FindPropertyRelative("values");

        position.height = lineHeight;

        // Draw foldout
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label, true);

        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;

            // Draw each key-value pair
            for (int i = 0; i < keys.arraySize; i++)
            {
                position.y += lineHeight + spacing;

                var key = keys.GetArrayElementAtIndex(i);
                var value = values.GetArrayElementAtIndex(i);

                var keyRect = new Rect(position.x, position.y, position.width / 2 - 5, lineHeight);
                var valueRect = new Rect(position.x + position.width / 2 + 5, position.y, position.width / 2 - 5, lineHeight);

                EditorGUI.PropertyField(keyRect, key, GUIContent.none);
                EditorGUI.PropertyField(valueRect, value, GUIContent.none);
            }

            // Add button
            position.y += lineHeight + spacing;
            if (GUI.Button(position, "Add Entry"))
            {
                keys.arraySize++;
                values.arraySize++;
            }

            // Remove button
            if (keys.arraySize > 0)
            {
                position.y += lineHeight + spacing;
                if (GUI.Button(position, "Remove Last Entry"))
                {
                    keys.arraySize--;
                    values.arraySize--;
                }
            }

            EditorGUI.indentLevel--;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = lineHeight;

        if (property.isExpanded)
        {
            var keys = property.FindPropertyRelative("keys");
            height += (lineHeight + spacing) * (keys.arraySize + 2);
        }

        return height;
    }
}
#endif