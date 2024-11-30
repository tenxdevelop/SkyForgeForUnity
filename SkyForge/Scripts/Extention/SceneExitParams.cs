/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Extention
{
    public abstract class SceneExitParams
    {
        public SceneEnterParams TargetEnterParams { get; }
        public SceneExitParams(SceneEnterParams targetEnterParams)
        {
            TargetEnterParams = targetEnterParams;
        }
    }
}
