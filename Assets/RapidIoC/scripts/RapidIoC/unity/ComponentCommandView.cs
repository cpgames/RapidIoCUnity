namespace cpGames.core.RapidIoC
{
    public abstract class ComponentCommandView : CommandView
    {
        #region Fields
        protected readonly ComponentView _owner;
        #endregion

        #region Properties
        public override string ContextName => _owner.ContextName;
        #endregion

        #region Constructors
        protected ComponentCommandView(ComponentView owner)
        {
            _owner = owner;
        }
        #endregion
    }

    public abstract class ComponentCommandView<TModel> : CommandView<TModel>
    {
        #region Fields
        protected readonly ComponentView _owner;
        #endregion

        #region Properties
        public override string ContextName => _owner.ContextName;
        #endregion

        #region Constructors
        protected ComponentCommandView(ComponentView owner)
        {
            _owner = owner;
        }
        #endregion
    }

    public abstract class ComponentCommandView<TModel1, TModel2> : CommandView<TModel1, TModel2>
    {
        #region Fields
        protected readonly ComponentView _owner;
        #endregion

        #region Properties
        public override string ContextName => _owner.ContextName;
        #endregion

        #region Constructors
        protected ComponentCommandView(ComponentView owner)
        {
            _owner = owner;
        }
        #endregion
    }
}