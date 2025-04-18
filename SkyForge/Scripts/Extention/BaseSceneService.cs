/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;
using System;

namespace SkyForge.Extension
{
    public abstract class BaseSceneService : IDisposable
    {
        public event UnityAction<Scene, LoadSceneMode, SceneEnterParams> LoadSceneEvent;

        private SceneEnterParams m_targerEnterParams;

        public BaseSceneService()
        {
            SceneManager.sceneLoaded += OnLoadScene;
        }
        
        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnLoadScene;
            OnDispose();
        }
        
        public string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        protected virtual void OnDispose() { }
        
        protected IEnumerator LoadScene(string sceneName, SceneEnterParams sceneEnterParams = null)
        {
            m_targerEnterParams = sceneEnterParams;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        private void OnLoadScene(Scene scene, LoadSceneMode loadSceneMode)
        {
            LoadSceneEvent?.Invoke(scene, loadSceneMode, m_targerEnterParams);
        }
    }
}
