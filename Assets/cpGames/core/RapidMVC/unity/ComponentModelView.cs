namespace cpGames.core.RapidMVC
{
    /// <summary>
    /// View with a model for convenience.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class ComponentModelView<TModel> : ComponentView
    {
        #region Fields
        private TModel _model;
        #endregion

        #region Properties
        public virtual TModel Model
        {
            get => _model;
            set
            {
                if (ReferenceEquals(_model, value))
                {
                    return;
                }
                _model = value;
                UpdateModel();
                ModelUpdatedSignal.Dispatch();
            }
        }

        public bool HasModel => _model != null;
        public Signal ModelUpdatedSignal { get; } = new Signal();
        #endregion

        #region Methods
        /// <summary>
        /// Implement your logic here when model is updated.
        /// </summary>
        protected virtual void UpdateModel() { }
        #endregion
    }
}