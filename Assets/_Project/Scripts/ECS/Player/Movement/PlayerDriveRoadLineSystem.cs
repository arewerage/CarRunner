using System;
using _Project.Scripts.ECS.Common.Movement;
using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Project.Scripts.ECS.Player.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PlayerDriveRoadLineSystem : IFixedSystem
    {
        private readonly IStaticDataProvider<LevelStaticData> _levelStaticData;

        private LevelStaticData _levelData;
        private Stash<RoadLineComponent> _roadLineStash;
        private Stash<RigidbodyComponent> _rigidbodyStash;
        private Stash<SlidingTimeComponent> _slidingTimeStash;
        private Stash<VelocityComponent> _velocityStash;
        private Filter _players;
        private Vector3 _currentVelocity;
        
        public World World { get; set; }

        public PlayerDriveRoadLineSystem(IStaticDataProvider<LevelStaticData> levelStaticData)
        {
            _levelStaticData = levelStaticData;
        }

        public void OnAwake()
        {
            _levelData = _levelStaticData.Get();
            
            _roadLineStash = World.GetStash<RoadLineComponent>();
            _rigidbodyStash = World.GetStash<RigidbodyComponent>();
            _slidingTimeStash = World.GetStash<SlidingTimeComponent>();
            _velocityStash = World.GetStash<VelocityComponent>();
            _players = World.Filter.With<RoadLineComponent>().With<ViewComponent<PlayerEntityView>>()
                .With<RigidbodyComponent>().With<SlidingTimeComponent>().With<VelocityComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                ref var roadLine = ref _roadLineStash.Get(player);
                ref var rigidbody = ref _rigidbodyStash.Get(player);
                ref var slidingTime = ref _slidingTimeStash.Get(player);
                ref var velocity = ref _velocityStash.Get(player);

                velocity.Value.x = _currentVelocity.x;
                
                if (roadLine.Current == roadLine.Target)
                    continue;

                Vector3 start = rigidbody.Value.position;
                Vector3 target = Vector3.right * _levelData.GetRoadLineData(roadLine.Target).OffsetX;
                Vector3 lerp = Vector3.SmoothDamp(start, target, ref _currentVelocity, deltaTime * slidingTime.Value);
                
                rigidbody.Value.MovePosition(lerp);

                if (Math.Abs(rigidbody.Value.position.x - target.x) > 0.05f)
                    continue;
                
                roadLine.Current = roadLine.Target;
                _currentVelocity = Vector3.zero;
            }
        }

        public void Dispose()
        {
        }
    }
}