/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System;

namespace SkyForge.Input
{
    public abstract class BaseInputManager : IDisposable
    {
        protected IInputMap m_inputMap;
        
        private Dictionary<Type, object> m_inputs;
        
        public BaseInputManager(IInputMap inputMap)
        {
            m_inputMap = inputMap;
            m_inputMap.Enable();
            m_inputs = new Dictionary<Type, object>();
        }

        public virtual void Dispose()
        {
            m_inputMap.Disable();
        }

        public abstract void Init();

        public void RegisterInput<TInputInterface, TInput>() where TInput : class, IInput where TInputInterface : IInput
        {
            var typeInterfaceInput = typeof(TInputInterface);
            var typeInput = typeof(TInput);

            if (m_inputs.ContainsKey(typeInterfaceInput))
            {
                var currentInputs = m_inputs[typeInterfaceInput] as IList<TInputInterface>;
                
                if (currentInputs.Any(input => input is TInput))
                    return;
                
                var newInput = (TInputInterface)Activator.CreateInstance(typeInput, new object[] { m_inputMap });
                currentInputs.Add(newInput);
                
                return;
            }
            
            var input = (TInputInterface)Activator.CreateInstance(typeInput, new object[] { m_inputMap });
            var inputs = new List<TInputInterface>();
            
            inputs.Add(input);
            
            m_inputs.Add(typeInterfaceInput, inputs);
        }

        protected IList<TInputInterface> GetInputs<TInputInterface>() where TInputInterface : IInput
        {
            var typeInput = typeof(TInputInterface);
            
            if (m_inputs.TryGetValue(typeInput, out var inputs))
            {
                return (IList<TInputInterface>)inputs;
            }
            
            return null;
        }
    }
}
