namespace cpGames.core.RapidMVC
{
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
        protected virtual void UpdateModel() { }
        #endregion
    }
}