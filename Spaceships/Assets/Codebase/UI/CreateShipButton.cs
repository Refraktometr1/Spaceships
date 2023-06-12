using System;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.UI
{
    public class CreateShipButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(CreateShip);
        }

        private void CreateShip()
        {
            
        }
    }
}