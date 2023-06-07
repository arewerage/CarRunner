namespace _Project.Scripts.Services.Pools
{
    [System.Serializable]
    public class PoolData<T>
    {
        public int Size;
        public string ContainerName;
        public T[] Prefabs;
    }
}