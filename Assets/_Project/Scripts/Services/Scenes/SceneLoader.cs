using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Services.Scenes
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadAsync(string name, IProgress<float> progress = null)
        {
            await SceneManager.LoadSceneAsync(name).ToUniTask(progress);
        }
    }
}