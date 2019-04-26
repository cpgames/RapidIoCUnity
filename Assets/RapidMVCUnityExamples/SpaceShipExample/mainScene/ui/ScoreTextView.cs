using UnityEngine;
using UnityEngine.UI;

namespace cpGames.core.RapidMVC.examples.invadersExample
{
    // ScoreTextView serves an example of multiple views listening to the same signal and each performing a subset of game logic
    [RequireComponent(typeof(Text))]
    public class ScoreTextView : ComponentModelView<int>
    {
        #region Properties
        [Inject("Score")]
        public override int Model { get => base.Model; set => base.Model = value; }
        #endregion

        #region Methods
        protected override void UpdateModel()
        {
            GetComponent<Text>().text = string.Format("Score: {0}", Model);
        }
        #endregion
    }
}