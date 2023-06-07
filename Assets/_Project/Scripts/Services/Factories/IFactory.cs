namespace _Project.Scripts.Services.Factories
{
    public interface IFactory<in TParam1, out TResult>
    {
        TResult Create(TParam1 param);
    }
    
    public interface IFactory<in TParam1, in TParam2, out TResult>
    {
        TResult Create(TParam1 param1, TParam2 param2);
    }
    
    public interface IFactory<in TParam1, in TParam2, in TParam3, out TResult>
    {
        TResult Create(TParam1 param1, TParam2 param2, TParam3 param3);
    }
}