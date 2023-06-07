using _Project.Scripts.Services.StaticData;
using _Project.Scripts.UI.Screens;
using UnityEngine;

namespace _Project.Scripts.StaticData.UI.Screens
{
    public enum ScreenTypeId
    {
        HUD = 0,
    }
    
    [CreateAssetMenu(menuName = "StaticData/Screen", fileName = "ScreenStaticData")]
    public class ScreenStaticData : StaticDataTypedBase<ScreenTypeId>
    {
        [SerializeField] private BaseScreen _prefab;

        public BaseScreen Prefab => _prefab;
    }
}