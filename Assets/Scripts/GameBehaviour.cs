using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameBehaviour : MonoBehaviour
    {
        private int _playerHP;
        public int playerHP
        {
            get { return _playerHP; }
            set { _playerHP = value; }
        }
        private int _emeryHP;
        public int emeryHP
        {
            get { return _emeryHP; }
            set { _emeryHP = value; }
        }
        void Start()
        {

        }

        
        void Update()
        {

        }
    }
}