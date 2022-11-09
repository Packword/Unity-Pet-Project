namespace Assets.CodeBase.Core
{
    public interface ISaveLoadService: IService
    {
        public void Save();
        public void Load();
    }
}
