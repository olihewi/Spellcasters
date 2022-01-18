using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting.Nodes;
using UnityEngine;

namespace Spellcasting
{
    public class Spellcaster : MonoBehaviour
    {
        public static Spellcaster instance;
        public Rigidbody player;
        public SpellcraftingGrid spellcraftingGrid;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            StaticInput.input.Gameplay.OpenProgramming.performed += _ => ToggleCasting();
        }

        private void Update()
        {
            foreach (KeyValuePair<Vector2Int, Node> nodePair in spellcraftingGrid.tiles)
            {
                nodePair.Value.Tick();
            }
            foreach (KeyValuePair<Vector2Int, Node> nodePair in spellcraftingGrid.tiles)
            {
                nodePair.Value.Execute();
            }
        }

        public void ToggleCasting()
        {
            spellcraftingGrid.gameObject.SetActive(!spellcraftingGrid.gameObject.activeSelf);
        }
    }
}

