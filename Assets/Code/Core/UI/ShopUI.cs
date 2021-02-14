using System;
using System.Collections.Generic;
using Code.Eco;
using UnityEngine;

namespace Code.Core.UI
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private Transform _commonParent;
        [SerializeField] private Transform _ballListParent;
        [SerializeField] private Transform _playerListParent;
        
        [SerializeField] private GameObject _cellPrefab;
        
        
        private List<Skin> _torusSkins; 
        private List<Skin> _ballSkins;
        private GameStateHandler _gameStateHandler;
        private bool _open;
        private CellUI _selectedBall;
        private CellUI _selectedTorus;
        public void Start()
        {
            _torusSkins = SkinHandler.Instance.PlayerSkins;
            _ballSkins = SkinHandler.Instance.BallSkins;
            Debug.Log(_torusSkins.Count);
            CreateAll();
            _gameStateHandler = GameStateHandler.Instance;
           // UpdateSelected();
        }

        public void ChangeVisibility()
        {
            _commonParent.gameObject.SetActive(_open);
            _open = !_open;
        }
      

        private void CreateAll()
        {
            for (var index = 0; index < _torusSkins.Count; index++)
            {
                Skin torusSkin = _torusSkins[index];
                GameObject go = Instantiate(_cellPrefab,_playerListParent);
                CellUI cellUI = go.GetComponent<CellUI>();
                cellUI.SetupSkinUI(index,torusSkin, SkinType.Torus, this);
            }

            for (var index = 0; index < _ballSkins.Count; index++)
            {
                Skin ballSkin = _ballSkins[index];
                GameObject go = Instantiate(_cellPrefab,_ballListParent);
                CellUI cellUI = go.GetComponent<CellUI>();
                cellUI.SetupSkinUI(index,ballSkin, SkinType.Ball, this);
            }
        }

        public void OnSkinSelect(CellUI cellUI)
        {
            if (cellUI.SkinType == SkinType.Ball)
            {
                if(_selectedBall != null)
                    _selectedBall.Deselect();
                _gameStateHandler.State.BallSkin = cellUI.Index;
                _selectedBall = cellUI;
            }
            else
            {
                if(_selectedTorus != null)
                    _selectedTorus.Deselect();
                _gameStateHandler.State.TorusSkin = cellUI.Index;
                _selectedTorus = cellUI;
            }
            
        }
        
    }
}