using System.Collections.Generic;
using cpGames.core.RapidIoC.impl;
using UnityEngine;

namespace cpGames.core.RapidIoC
{
    /// <summary>
    /// Base class for all views deriving from MonoBehavior.
    /// </summary>
    public class ComponentView : MonoBehaviour, IComponent
    {
        #region Fields
        private string _contextName;
        #endregion

        #region IComponent Members
        public Signal DestroyedSignal { get; } = new Signal();
        public virtual string ContextName => _contextName;
        public List<ISignalMapping> SignalMappings { get; } = new List<ISignalMapping>();
        public bool IsReady { get; private set; }
        public Signal ReadySignal { get; } = new Signal();

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
            IsReady = true;
            ReadySignal.Dispatch();
        }

        protected virtual void OnDestroy()
        {
            DestroyedSignal.Dispatch();
            UnregisterFromContext();
        }
        #endregion
    }
}