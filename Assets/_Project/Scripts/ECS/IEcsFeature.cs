using Scellecs.Morpeh;

namespace _Project.Scripts.ECS
{
    public interface IEcsFeature
    {
        void InitializeFeature(SystemsGroup systemsGroup);
    }
}