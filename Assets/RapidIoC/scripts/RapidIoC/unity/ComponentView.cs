using System;
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

        #region Properties
        public virtual bool RegistersWithContext => true;
        #endregion

        #region IComponent Members
        public Signal DestroyedSignal { get; } = new Signal();
        public GameObject GameObject => gameObject;
        public virtual string ContextName => _contextName;
        public bool IsReady { get; private set; }
        public Signal ReadySignal { get; } = new Signal();

        public void RegisterWithContext()
        {
            if (!RegistersWithContext)
            {
                return;
            }
            var context = transform.FindFirstParent<SceneView>();
            if (context == null)
            {
                throw new Exception(GetType().Name);
            }
            _contextName = transform.FindFirstParent<SceneView>().ContextName;
            Rapid.RegisterView(this);
        }

        public void UnregisterFromContext()
        {
            if (!RegistersWithContext)
            {
                return;
            }
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