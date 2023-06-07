using _Project.Scripts.ECS.Common.Collisions;
using _Project.Scripts.ECS.Common.Movement;
using Scellecs.Morpeh;

namespace _Project.Scripts.ECS.Common
{
    public class CommonFeature : IEcsFeature
    {
        public void InitializeFeature(SystemsGroup systemsGroup)
        {
            systemsGroup.AddSystem(new MovementSystem());
            systemsGroup.AddSystem(new ClearTriggerEventSystem());
        }
    }
}