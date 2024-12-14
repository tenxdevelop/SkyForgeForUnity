/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.FSM
{
    public interface IState
    {
        void OnStart();
        void OnUpdate(float deltaTime);
        void OnPhysicsUpdate(float deltaTime);
        void OnExit();
    }
}
