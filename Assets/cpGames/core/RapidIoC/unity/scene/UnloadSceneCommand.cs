using System;

namespace cpGames.core.RapidIoC
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