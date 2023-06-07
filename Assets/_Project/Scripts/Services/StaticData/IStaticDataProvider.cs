namespace _Project.Scripts.Services.StaticData
{
    public interface IStaticDataProvider<out TStaticData>
    {
        void Load(string path);
        TStaticData Get();
    }
    
    public interface IStaticDataProvider<in TTypeId, out TStaticData>
    {
        void LoadAll(string folder);
        TStaticData Get(TTypeId typeId);
    }
}