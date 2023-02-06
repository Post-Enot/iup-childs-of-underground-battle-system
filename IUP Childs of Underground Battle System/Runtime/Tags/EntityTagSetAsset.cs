using System;
using System.Collections.Generic;
using IUP.Toolkits.SerializableCollections;
using UnityEngine;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    [CreateAssetMenu(fileName = "Entity Tag Set", menuName = "IUP/Battle Entity Tag Set")]
    public sealed class EntityTagSetAsset : ScriptableObject
    {
        [Serializable] private sealed class EntityTagSet : SHashSet<string> { }

        public IEnumerable<string> Tags => _entityTags.Value;

        [SerializeField] private EntityTagSet _entityTags = new();
    }
}
