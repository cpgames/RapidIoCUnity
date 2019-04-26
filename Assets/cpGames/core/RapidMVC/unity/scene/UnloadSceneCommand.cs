using System;

namespace cpGames.core.RapidMVC
{
    public class UnloadSceneCommand : Command<Type>
    {
        #region Methods
        public override void Execute(Type sceneType)
        {
            CpUnityExtensions.UnloadLevelAdditive(sceneType);
        }
        #endregion
    }
}