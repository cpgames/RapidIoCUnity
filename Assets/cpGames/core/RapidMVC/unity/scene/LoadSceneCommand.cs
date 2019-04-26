using System;

namespace cpGames.core.RapidMVC
{
    public class LoadSceneCommand : Command<Type>
    {
        #region Methods
        public override void Execute(Type sceneType)
        {
            CpUnityExtensions.LoadLevelAdditive(sceneType);
        }
        #endregion
    }
}