﻿using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stacker.ScriptableObjects
{
    [CreateAssetMenu(menuName ="Data/DyingCellSettings")]
    public class DyingCellSettings : ScriptableObject
    {
        [SerializeField] private AnimationCurve fadeCurve;
        [SerializeField] private AnimationCurve jumpCurve;
        [SerializeField] private float jumpLength;
        [SerializeField] private float maxJumpXDistance;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float rotationDampener;


        public AnimationCurve JumpCurve
        {
            get
            {
                return jumpCurve;
            }
        }

        public float JumpLength
        {
            get
            {
                return jumpLength;
            }
        }
        
        public float JumpXDistance
        {
            get
            {
                return Random.Range(-maxJumpXDistance, maxJumpXDistance);
            }
        }

        public float RotationDampener
        {
            get
            {
                return rotationDampener;
            }
        }

        public float RotationSpeed
        {
            get
            {
                return rotationSpeed;
            }
        }

        public AnimationCurve FadeCurve
        {
            get
            {
                return fadeCurve;
            }
        }
    }
}