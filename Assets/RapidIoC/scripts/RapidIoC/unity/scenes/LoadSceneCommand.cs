﻿using System;

namespace cpGames.core.RapidIoC
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