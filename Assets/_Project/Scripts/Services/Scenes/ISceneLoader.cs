using System;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Services.Scenes
{
    public interface ISceneLoader
    {
        UniTask LoadAsync(string name, IProgress<float> progress = null);
    }
}