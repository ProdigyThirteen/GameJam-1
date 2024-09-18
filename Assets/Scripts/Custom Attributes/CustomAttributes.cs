using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomAttributes
{
    public class ReadOnlyAttribute : PropertyAttribute
    {
        // This is just a marker class
    }

    public class DividerAttribute : PropertyAttribute
    {
        public float thickness;
        public Color color;

        public DividerAttribute(float thickness, float r, float g, float b, float a)
        {
            this.thickness = thickness;
            this.color = new Color(r, g, b, a);
        }
    }

    public class CategoryAttribute : PropertyAttribute
    {
        public string label;
        public TextAnchor textAnchor;

        public CategoryAttribute(string categoryLabel, TextAnchor textAnchor)
        {
            this.label = categoryLabel;
            this.textAnchor = textAnchor;

        }
    }

    [Serializable]
    public class Map<TKey, TValue>
    {
        [SerializeField] private List<TKey> keys = new List<TKey>();
        [SerializeField] private List<TValue> values = new List<TValue>();

        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var pair in dictionary)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            dictionary.Clear();

            if (keys.Count != values.Count)
                throw new Exception("There are an unequal number of keys and values after deserialization.");

            for (int i = 0; i < keys.Count; i++)
            {
                dictionary[keys[i]] = values[i];
            }
        }

        public void Add(TKey key, TValue value)
        {
            dictionary[key] = value;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        public Dictionary<TKey, TValue>.KeyCollection Keys => dictionary.Keys;
        public Dictionary<TKey, TValue>.ValueCollection Values => dictionary.Values;

        public Dictionary<TKey, TValue> ToDictionary() => dictionary;
    }


}