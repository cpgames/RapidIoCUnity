using System;

namespace cpGames.core.RapidIoC
{
    [Flags]
    public enum SceneRelationshipType
    {
        Depend = 1,
        Exclude = 2,
        Include = 4
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class SceneRelationshipAttribute : Attribute
    {
        #region Properties
        public Type SceneType { get; }
        public SceneRelationshipType Relationship { get; }
        public int Order { get; }
        #endregion

        #region Constructors
        public SceneRelationshipAttribute(Type sceneType, SceneRelationshipType relationship, int order = 10)
        {
            SceneType = sceneType;
            Relationship = relationship;
            Order = order;
        }
        #endregion
    }
}