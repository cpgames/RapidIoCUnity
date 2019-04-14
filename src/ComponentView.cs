using System.Collections.Generic;
using cpGames.core.RapidMVC.impl;
using UnityEngine;

namespace cpGames.core.RapidMVC
{
    public class ComponentView : MonoBehaviour, IView
    {
        #region Fields
        private string _contextName;
        #endregion

        #region IView Members
        public virtual string ContextName => _contextName;
        public Signal<IBindingKey> PropertyUpdatedSignal { get; } = new Signal<IBindingKey>();
        public List<ISignalMapping> SignalMappings { get; } = new List<ISignalMapping>();

        public void RegisterWithContext()
        {
            _contextName = GetComponentInParent<SceneView>().ContextName;
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