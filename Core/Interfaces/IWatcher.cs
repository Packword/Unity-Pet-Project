namespace Assets.CodeBase.Core
{
    public interface IWatcher
    {
        public void Save(PersistentData persistentData);
        public void Load(PersistentData persistentData);
    }
}
