using Zenject;

namespace _Project.Scripts.Services.Input
{
    public class InputService : IInputService, IInitializable
    {
        private readonly Controls _controls;

        public float SlideAxis => _controls.Player.Move.ReadValue<float>();

        public InputService()
        {
            _controls = new Controls();
        }
        
        public void Initialize()
        {
            _controls.Player.Enable();
        }
    }
}