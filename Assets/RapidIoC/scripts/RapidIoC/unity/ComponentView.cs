using System.Collections.Generic;
using cpGames.core.RapidIoC.impl;
using UnityEngine;

namespace cpGames.core.RapidIoC
{
    /// <summary>
    /// Base class for all views deriving from MonoBehavior.
    /// </summary>
    public class ComponentView : MonoBehaviour, IView
    {
        #region Fields
        private string _contextName;
        #endregion

        #region IView Members
        public virtual string ContextName => _contextName;
        public List<ISignalMapping> SignalMappings { get; } = new List<ISignalMapping>();

        public void RegisterWithContext()
        {
            _contextName = transform.FindFirstParent<SceneView>().ContextName;
            Rapid.RegisterView(this);
        }

        public void UnregisterFromContext()
        {
            Rapid.UnregisterView(this);
        }
        #endregion

        #region Methods
        protected virtual void Awake()
        {
            RegisterWithContext();
        }

        protected virtual void OnDestroy()
        {
            UnregisterFromContext();
        }
        #endregion
    }
}