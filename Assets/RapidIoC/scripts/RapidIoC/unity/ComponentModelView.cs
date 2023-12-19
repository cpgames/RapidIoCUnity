using System;

namespace cpGames.core.RapidIoC
{
    /// <summary>
    /// View with a model for convenience.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class ComponentView<TModel> : ComponentView
    {
        #region Fields
        private TModel _model;
        #endregion

        #region Properties
        public virtual bool OneTimeSet => !AllowNull;
        public virtual bool AllowNull => false;

        public virtual TModel Model
        {
            get => _model;
            set
            {
                if (OneTimeSet && HasModel)
                {
                    throw new Exception($"ComponentView {name} is a one-time set, can not update model again.");
                }
                if (ReferenceEquals(_model, value))
                {
                    return;
                }
                BeginUpdateModel();
                _model = value;
                EndUpdateModelInternal();
            }
        }

        public virtual bool HasModel => AllowNull || _model != null;
        public Signal ModelSetSignal { get; } = new Signal();
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            EndUpdateModelInternal();
        }

        protected virtual void BeginUpdateModel() { }

        /// <summary>
        /// Implement your logic here when model is updated.
        /// </summary>
        protected virtual void EndUpdateModel() { }

        private void EndUpdateModelInternal()
        {
            if (HasModel && IsReady)
            {
                EndUpdateModel();
                ModelSetSignal.Dispatch();
            }
        }
        #endregion
    }
}