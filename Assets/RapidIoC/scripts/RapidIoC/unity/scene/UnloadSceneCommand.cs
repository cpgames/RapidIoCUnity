using System;
using UnityEngine;

namespace cpGames.core.RapidIoC
{
    public class UnloadSceneCommand : Command<Type>
    {
        #region Methods
        public override void Execute(Type sceneType)
        {
            CpUnityExtensions.UnloadLevelAdditive(sceneType, operation =>
            {
                var contextName = CpUnityExtensions.GetSceneName(sceneType);
                if (Rapid.Contexts.FindContext(contextName, out var context, out _))
                {
                    Debug.LogWarning(string.Format("Scene <{0}> is being destroyed while its context still exists with <{1}> bindings and <{2}> views.",
                        contextName, context.BindingCount, context.ViewCount));
                }
            });
        }
        #endregion
    }
}