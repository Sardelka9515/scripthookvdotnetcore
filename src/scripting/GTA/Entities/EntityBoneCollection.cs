//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

using System.Collections;

namespace GTA
{
    public class EntityBoneCollection : IEnumerable<EntityBone>
    {
        public class Enumerator : IEnumerator<EntityBone>
        {
            #region Fields

            readonly EntityBoneCollection collection;
            int currentIndex = -1; // Skip the CORE bone index(-1)

            #endregion

            public Enumerator(EntityBoneCollection collection)
            {
                this.collection = collection;
            }

            public EntityBone Current => collection[currentIndex];

            object IEnumerator.Current => collection[currentIndex];

            public void Reset()
            {
                currentIndex = -1;
            }

            public bool MoveNext()
            {
                return ++currentIndex < collection.Count;
            }

            void IDisposable.Dispose()
            {
            }
        }

        #region Fields

        protected readonly Entity _owner;

        #endregion

        internal EntityBoneCollection(Entity owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Gets the <see cref="EntityBone"/> at the specified bone index.
        /// </summary>
        /// <param name="boneIndex">The bone index.</param>
        public EntityBone this[int boneIndex]
        {
            get => new(_owner, boneIndex);
        }

        /// <summary>
        /// Gets the <see cref="EntityBone"/> with the specified bone name.
        /// </summary>
        /// <param name="boneName">Name of the bone.</param>
        public EntityBone this[string boneName]
        {
            get => new(_owner, boneName);
        }

        /// <summary>
        /// Gets the number of bones that this <see cref="Entity"/> has.
        /// </summary>
        public int Count => NativeMemory.GetEntityBoneCount(_owner.Handle);

        /// <summary>
        /// Determines whether this <see cref="Entity"/> has a bone with the specified bone name
        /// </summary>
        /// <param name="boneName">Name of the bone.</param>
        /// <returns>
        ///   <see langword="true" /> if this <see cref="Entity"/> has a bone with the specified bone name; otherwise, <see langword="false" />.
        /// </returns>
        public bool Contains(string boneName)
        {
            return Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, _owner.Handle, boneName) != -1;
        }

        /// <summary>
        /// Gets the core bone of this <see cref="Entity"/>.
        /// </summary>
        public EntityBone Core => new(_owner, -1);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<EntityBone> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public override int GetHashCode()
        {
            return _owner.GetHashCode() ^ Count.GetHashCode();
        }
    }
}