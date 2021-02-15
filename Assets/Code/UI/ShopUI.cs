using System.Collections.Generic;
using Code.Eco;
using Code.Eco.SkinShop;
using Code.States;
using UnityEngine;

namespace Code.UI
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
            _gameStateHandler = GameStateHandler.Instance;
            CreateAll();
        }

        public void ChangeVisibility()
        {
            _open = !_open;
            _commonParent.gameObject.SetActive(_open);
        }

        private void CreateAll()
        {
            for (int index = 0; index < _torusSkins.Count; index++)
            {
                var torusSkin = _torusSkins[index];
                var go = Instantiate(_cellPrefab, _playerListParent);
                var cellUI = go.GetComponent<CellUI>();
                cellUI.SetupSkinUI(index, torusSkin, SkinType.Torus, this);
            }

            for (int index = 0; index < _ballSkins.Count; index++)
            {
                var ballSkin = _ballSkins[index];
                var go = Instantiate(_cellPrefab, _ballListParent);
                go.transform.SetSiblingIndex(index);
                var cellUI = go.GetComponent<CellUI>();
                cellUI.SetupSkinUI(index, ballSkin, SkinType.Ball, this);
            }
        }

        public void OnSkinSelect(CellUI cellUI)
        {
            if (cellUI.SkinType == SkinType.Ball)
            {
                _gameStateHandler.State.BallSkin = HandleSelect(ref cellUI, ref _selectedBall);
            }
            else
            {
                _gameStateHandler.State.TorusSkin = HandleSelect(ref cellUI, ref _selectedTorus);
            }
        }

        private int HandleSelect(ref CellUI cellUI, ref CellUI current)
        {
            if (current != null && current.Index != cellUI.Index) 
                current.Deselect();
            current = cellUI;
            return cellUI.Index;
        }
    }
}