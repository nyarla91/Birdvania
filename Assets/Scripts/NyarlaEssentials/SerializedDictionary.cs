using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NyarlaEssentials
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue>
    {
        [SerializeField] private List<SerializedKeyValuePair<TKey, TValue>> _pairs;
        private Dictionary<TKey, TValue> _dictionary;

        public Dictionary<TKey, TValue> Dictionary => _dictionary ??= GenerateDictionary();
        
        public Dictionary<TKey, TValue> GenerateDictionary() => _dictionary = DictionaryFromSerializedPairs();

        private void OnValidate() => GenerateDictionary();

        private Dictionary<TKey, TValue> DictionaryFromSerializedPairs() =>
            _pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    [Serializable]
    public class SerializedKeyValuePair<TKey, TValue>
    {
        [SerializeField] private TKey _key;
        [SerializeField] private TValue _value;

        public TKey Key => _key;
        public TValue Value => _value;
    }
}