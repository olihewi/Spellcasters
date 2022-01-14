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
        public bool casting;
        public List<Node> nodes;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            nodes.AddRange(GetComponentsInChildren<Node>());
            StaticInput.input.Gameplay.OpenProgramming.performed += _ => ToggleCasting();
        }

        private void Update()
        {
            if (!casting) return;
            
            foreach (Node node in nodes)
            {
                node.Tick();
            }
            foreach (Node node in nodes)
            {
                node.Execute();
            }
        }

        public void ToggleCasting()
        {
            casting = !casting;
        }
    }
}

