﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stacker.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Theme List")]
    public class ThemeData : ScriptableObject
    {
        [SerializeField] private Theme[] themes;

        public Theme[] Themes
        {
            get
            {
                return themes;
            }
        }
    }

    [Serializable]
    public class Theme
    {
        [SerializeField] private Sprite sprite;
        
        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
        }
    }
}