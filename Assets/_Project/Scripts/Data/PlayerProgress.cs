using UniRx;

namespace _Project.Scripts.Data
{
    public class PlayerProgress
    {
        public readonly ReactiveProperty<int> Score = new(0);
    }
}