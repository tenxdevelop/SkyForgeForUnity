/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections;
using SkyForge.Reactive;

namespace SkyForge.Extension
{
    public interface IEntryPoint
    {
        IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams);
        IObservable<SceneExitParams> Run();
    }
}
