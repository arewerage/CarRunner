using Scellecs.Morpeh;

namespace _Project.Scripts.ECS.Boot
{
    public class BootFeature : IEcsFeature
    {
        public void InitializeFeature(SystemsGroup systemsGroup)
        {
            systemsGroup.AddInitializer(new BootstrapSystem());
        }
    }
}