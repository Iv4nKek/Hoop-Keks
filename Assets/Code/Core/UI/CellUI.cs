using System;
using Code.Eco;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Core.UI
{
    public enum SkinType
    {
        Ball,
        Torus
    }
    
    public class CellUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _background;
        [SerializeField] private Image _selectBorder;

        private SkinType _skinType;
        private int _index;

        public event Action<CellUI> OnSelect = delegate(CellUI cellUI) {  };

        public SkinType SkinType => _skinType;

        public int Index => _index;

        public void SetupSkinUI(int index,Skin skin, SkinType skinType, ShopUI shopUI)
        {
            _skinType = skinType;
            _image.sprite = skin.Icon;
            _index = index;
            OnSelect += shopUI.OnSkinSelect;
        }

        public void Select()
        {
            _selectBorder.gameObject.SetActive(true);
            OnSelect.Invoke(this);
        }

        public void Deselect()
        {
            _selectBorder.gameObject.SetActive(false);
        }
        
        
    }
}