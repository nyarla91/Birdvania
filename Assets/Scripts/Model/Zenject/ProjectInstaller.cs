using Model.Controls;
using UnityEngine;
using Zenject;

namespace Model.Zenject
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private DeviceUpdateWatcher _deviceUpdateWatcherPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<DeviceUpdateActions>().FromInstance(new DeviceUpdateActions()).AsSingle();
            BindDeviceUpdateWatcher();
        }

        private void BindDeviceUpdateWatcher()
        {
            DeviceUpdateWatcher deviceUpdateWatcher =
                Container.InstantiatePrefabForComponent<DeviceUpdateWatcher>(_deviceUpdateWatcherPrefab.gameObject);
            Container.Bind<DeviceUpdateWatcher>().FromInstance(deviceUpdateWatcher);
        }
    }
}