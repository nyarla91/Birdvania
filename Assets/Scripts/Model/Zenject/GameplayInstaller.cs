using Model.Controls;
using Model.Gameplay.Player;
using Model.Gameplay.UI;
using NyarlaEssentials;
using UnityEngine;
using Zenject;

namespace Model.Zenject
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private MainCanvas _mainCanvas;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CameraProperties _cameraProperties;
        
        public override void InstallBindings()
        {
            Container.Bind<MainCanvas>().FromInstance(_mainCanvas).AsSingle();
            Container.Bind<GameplayControls>().FromInstance(new GameplayControls()).AsSingle();
            Container.Bind<CameraProperties>().FromInstance(_cameraProperties).AsSingle();
            InstantiateAndBindComponent<PlayerMarker>(_playerPrefab);
        }

        private void InstantiateAndBindComponent<T>(GameObject prefab)
        {
            T obj = Container.InstantiatePrefabForComponent<T>
                (prefab, Vector3.zero, Quaternion.identity, null);
            Container.Bind<T>().FromInstance(obj).AsSingle();
        }
    }
}
