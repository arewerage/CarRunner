using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Extensions;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Input;
using _Project.Scripts.StaticData;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Project.Scripts.ECS.Player.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PlayerInputSystem : ISystem
    {
        private readonly IInputService _inputService;

        private Stash<RoadLineComponent> _roadLineStash;
        private Filter _players;
        
        public World World { get; set; }

        public PlayerInputSystem(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void OnAwake()
        {
            _roadLineStash = World.GetStash<RoadLineComponent>();
            _players = World.Filter.With<RoadLineComponent>().With<ViewComponent<PlayerEntityView>>();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inputService.SlideAxis == 0)
                return;
            
            foreach (Entity player in _players)
            {
                ref var roadLine = ref _roadLineStash.Get(player);
                
                if (roadLine.Current != roadLine.Target)
                    continue;

                int slideAxis = Mathf.RoundToInt(_inputService.SlideAxis);
                
                if (roadLine.Current.TryGetNextByDirection(slideAxis, out RoadLineTypeId targetRoadLine) == false)
                    continue;

                roadLine.Target = targetRoadLine;
            }
        }

        public void Dispose()
        {
        }
    }
}