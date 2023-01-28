using System.Collections;
using System.Collections.Generic;

namespace IUP.ChildsOfUnderground.BattleSystem
{
    public sealed class TagSet : IReadonlyTagSet
    {
        public TagSet()
        {
            _tags = new HashSet<string>();
        }

        public TagSet(IEnumerable<string> tags)
        {
            _tags = new HashSet<string>(tags);
        }

        public IReadOnlyCollection<string> Tags => _tags;

        private readonly HashSet<string> _tags;

        public bool HasTag(string tag)
        {
            return _tags.Contains(tag);
        }

        public bool AddTag(string tag)
        {
            return _tags.Add(tag);
        }

        public void AddTags(params string[] tags)
        {
            foreach (string tag in tags)
            {
                _ = _tags.Add(tag);
            }
        }

        public bool RemoveTag(string tag)
        {
            return _tags.Remove(tag);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Tags.GetEnumerator();
        }
    }
}
