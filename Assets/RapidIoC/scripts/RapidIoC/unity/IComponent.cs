using UnityEngine;

namespace cpGames.core.RapidIoC
{
    /// <summary>
    /// Unity-friendly extension of the IView with the Destroyed signal
    /// </summary>
    public interface IComponent : IView
    {
        #region Properties
        bool IsReady { get; }
        Signal ReadySignal { get; }
        /// <summary>
        /// Notifies when ComponentView gameobject was destroyed in Unity
        /// </summary>
        Signal DestroyedSignal { get; }

        GameObject GameObject { get; }
        #endregion
    }
}