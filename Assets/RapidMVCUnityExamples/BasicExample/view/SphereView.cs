using UnityEngine;

namespace cpGames.core.RapidMVC.examples.basicExample
{
    public class SphereView : ComponentModelView<SphereModel>
    {
        #region Properties
        [Inject]
        public override SphereModel Model { get => base.Model; set => base.Model = value; }
        #endregion

        #region Methods
        protected override void UpdateModel()
        {
            GetComponent<Renderer>().material.SetColor("_Color", Model.color);
        }
        #endregion
    }
}