﻿using HenderStudios.Events;
using Sirenix.OdinInspector;
using Stacker.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stacker
{
    public class TetroController : MonoBehaviour
    {
        [SerializeField, ReadOnly] private Tetro tetro;
        [SerializeField] private float shiftSpeed;

        private TetroGrid grid;

        //private void Start()
        //{
        //    EventManager.StartListening(EventNames.InputReceived, OnInputReceived);
        //}

        private void Awake()
        {
            grid = FindObjectOfType<TetroGrid>();
            EventManager.StartListening(EventNames.NewTetroFalling, SwitchTetroControl);
            EventManager.StartListening(EventNames.InputReceived, OnInputReceived);
        }

        private void SwitchTetroControl(Message msg)
        {
            Tetro t = msg.Data as Tetro;
            t.OnDie.AddListener(RemoveTetroControl);
            tetro = t;
        }

        private void RemoveTetroControl()
        {
            tetro.OnDie.RemoveListener(RemoveTetroControl);
            tetro = null;
        }

        private void OnInputReceived(Message msg)
        {
            if (tetro == null)
                return;
            InputType input = (InputType)msg.Data;
            ResolveInput(input);
        }

        private void ResolveInput(InputType input)
        {
            switch (input)
            {
                case InputType.TetroRight:
                    ShiftRight();
                    break;
                case InputType.TetroLeft:
                    ShiftLeft();
                    break;
                case InputType.TetroDrop:
                    break;
                case InputType.TetroClockwise:
                    break;
                case InputType.TetroCounterClockwise:
                    break;
            }
        }

        private void ShiftRight()
        {
            StartCoroutine(Shift(grid.Grid.cellSize.x));
        }

        private void ShiftLeft()
        {
            StartCoroutine(Shift(grid.Grid.cellSize.x * -1));
        }

        private IEnumerator Shift(float newXPos)
        {
            SnapXPos();

            Vector3 startPos = tetro.transform.position;

            Vector2 nextCellPos = newXPos > 0 ? grid.GetCellPosRight(startPos) : grid.GetCellPosLeft(startPos);
            Vector2 endPos = new Vector2(nextCellPos.x, tetro.transform.position.y);

            if (grid.IsOutOfBounds(endPos))
                yield break;

            float time = 0;
            while (time < shiftSpeed)
            {
                time += Time.deltaTime;
                float perc = time / shiftSpeed;
                float xPos = Vector3.Lerp(startPos, endPos, perc).x;
                tetro.transform.position = new Vector3(xPos, tetro.transform.position.y);
                yield return null;
            }

            SnapXPos();
        }

        private void SnapXPos()
        {
            Vector2 cellPos = grid.GetCellPosAt(tetro.transform.position);
            tetro.transform.position = new Vector3(cellPos.x, tetro.transform.position.y);
        }
    }
}