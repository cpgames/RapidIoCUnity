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

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SceneRelationshipAttribute : Attribute
    {
        #region Properties
        public string SceneName { get; }
        public SceneRelationshipType Relationship { get; }
        public int Order { get; }
        #endregion

        #region Constructors
        public SceneRelationshipAttribute(string sceneName, SceneRelationshipType relationship, int order = 10)
        {
            SceneName = sceneName;
            Relationship = relationship;
            Order = order;
        }
        #endregion
    }
}