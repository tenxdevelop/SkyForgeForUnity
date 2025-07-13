/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using Unity.Netcode;
using System;

namespace SkyForge.Extension
{
    public abstract class BaseSceneService : IDisposable
    {
        public event UnityAction<Scene, LoadSceneMode, SceneEnterParams> LoadSceneEvent;

        public event Action<string, LoadSceneMode, List<ulong>, List<ulong>, SceneEnterParams> NetworkLoadSceneCompletedEvent;
        
        private SceneEnterParams m_targetEnterParams;

        public BaseSceneService()
        {
            SceneManager.sceneLoaded += OnLoadScene;
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += OnNetworkLoadSceneCompleted;
        }

        

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnLoadScene;
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted -= OnNetworkLoadSceneCompleted;
            
            OnDispose();
        }
        
        public string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        protected virtual void OnDispose() { }
        
        protected IEnumerator LoadScene(string sceneName, SceneEnterParams sceneEnterParams = null)
        {
            m_targetEnterParams = sceneEnterParams;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        private void OnLoadScene(Scene scene, LoadSceneMode loadSceneMode)
        {
            LoadSceneEvent?.Invoke(scene, loadSceneMode, m_targetEnterParams);
        }
        
        private void OnNetworkLoadSceneCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
        {
            NetworkLoadSceneCompletedEvent?.Invoke(sceneName, loadSceneMode, clientsCompleted, clientsTimedOut, m_targetEnterParams);
        }
    }
}
