/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace SkyForge.MVVM.Binders.Infrastructure
{
    [Serializable]
    public class IntToSpriteMapping
    {
        [SerializeField] private int m_value;
        [SerializeField] private Sprite m_sprite;

        public int Value => m_value;
        public Sprite Sprite => m_sprite;
    }
}