namespace cpGames.core.RapidIoC
{
    public class LoadSceneCommand : Command<string>
    {
        #region Methods
        public override void Execute(string sceneName)
        {
            CpUnityExtensions.LoadLevelAdditive(sceneName);
        }
        #endregion
    }
}