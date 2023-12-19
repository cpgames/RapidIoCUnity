using UnityEngine;

namespace cpGames.core.RapidIoC
{
    public class UnloadSceneCommand : Command<string>
    {
        #region Methods
        public override void Execute(string sceneName)
        {
            CpUnityExtensions.UnloadLevelAdditive(sceneName, operation =>
            {
                if (Rapid.Contexts.FindContext(sceneName, out var context, out _))
                {
                    Debug.LogWarning(
                        $"Scene <{sceneName}> is being destroyed while its context still exists with " +
                        $"<{context.BindingCount}> bindings and <{context.ViewCount}> views.");
                }
            });
        }
        #endregion
    }
}