/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


using SkyForge.Reactive;
using System.Collections;

namespace SkyForge.Extention
{
    public interface IEntryPoint
    {
        IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams);
        IObservable<SceneExitParams> Run();
    }
}
