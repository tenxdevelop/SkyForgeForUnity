/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace SkyForge.MVVM.Binders.Infrastructure
{
    [Serializable]
    public class IntToColorMapping
    {
        [SerializeField] private int m_value;
        [SerializeField] private Color m_color = Color.white;

        public int Value => m_value;
        public Color Color => m_color;
    }
}
