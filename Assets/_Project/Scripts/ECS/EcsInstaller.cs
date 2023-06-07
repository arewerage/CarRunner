using _Project.Scripts.ECS.Boot;
using _Project.Scripts.ECS.Common;
using _Project.Scripts.ECS.Level;
using _Project.Scripts.ECS.Obstacles;
using _Project.Scripts.ECS.Player;
using _Project.Scripts.ECS.Score;
using Zenject;

namespace _Project.Scripts.ECS
{
    public class EcsInstaller : Installer<EcsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEcsFeature>()
                .To(
                    typeof(BootFeature),
                    typeof(LevelFeature),
                    typeof(PlayerFeature),
                    typeof(ObstacleFeature),
                    typeof(ScoreFeature),
                    typeof(CommonFeature)
                ).AsSingle();

            Container.Bind<IEcsWorld>().To<EcsWorld>().AsSingle();
        }
    }
}