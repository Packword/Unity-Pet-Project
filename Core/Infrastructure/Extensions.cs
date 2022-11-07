namespace Assets.CodeBase.Core
{
    internal class Extensions
    {
        private static Extensions _instance;
        public static Extensions Instance => _instance ??= new Extensions();

        public void RegisterService<TService>(TService implementation)
            where TService : IService
            => Implementation<TService>.Container = implementation;

        public TService GetService<TService>() where TService : IService
            => Implementation<TService>.Container;


        private class Implementation<TService> where TService: IService
        {
            public static TService Container;
        }
    }
}
