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
        
        private Dictionary<Type, IList<IInput>> m_inputs;
        
        public BaseInputManager(IInputMap inputMap)
        {
            m_inputMap = inputMap;
            m_inputMap.Enable();
            m_inputs = new Dictionary<Type, IList<IInput>>();
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
                if (m_inputs[typeInterfaceInput].Any(input => input is TInput))
                    return;
                
                var newInput = Activator.CreateInstance(typeInput, new object[] { m_inputMap }) as TInput;
                m_inputs[typeInterfaceInput].Add(newInput);
                
                return;
            }
            
            var input = Activator.CreateInstance(typeInput, new object[] { m_inputMap }) as TInput;
            var inputs = new List<IInput>();
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
