namespace Assets.CodeBase.Core
{
    public interface ISaveLoadService: IService
    {
        public void SaveAll();
        public void Load();
    }
}
