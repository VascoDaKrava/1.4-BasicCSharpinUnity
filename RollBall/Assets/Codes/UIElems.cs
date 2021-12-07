using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kravchuk
{
    public sealed class UIElems
    {
        private TextMeshProUGUI _textMeshHealth;
        private TextMeshProUGUI _textMeshSpeed;
        private TextMeshProUGUI _textMeshWin;

        private GameObject _menu;

        private Dictionary<ButtonsName, Button> _buttonsDic;
        
        private TextMeshProUGUI _menuText;

        /// <summary>
        /// Text field for Health
        /// </summary>
        public string HealthTextValue {
            set
            {
                _textMeshHealth.text = value;   
            }
        }

        /// <summary>
        /// Color of text field for Health
        /// </summary>
        public Color HealthTextColor { 
            set
            {
                _textMeshHealth.color = value;
            }
        }

        /// <summary>
        /// Text field for Speed
        /// </summary>
        public string SpeedTextValue {
            set
            {
                _textMeshSpeed.text = value;
            }
        }

        /// <summary>
        /// Color of text field for Speed
        /// </summary>
        public Color SpeedTextColor
        {
            set
            {
                _textMeshSpeed.color = value;
            }
        }

        /// <summary>
        /// Text field for Win-points
        /// </summary>
        public string WinTextValue 
        {
            set
            {
                _textMeshWin.text = value;
            }
        }

        /// <summary>
        /// Text field for Menu
        /// </summary>
        public string MenuText
        {
            set
            {
                _menuText.text = value;
            }
        }

        /// <summary>
        /// Set or get visibility for Menu. Stop updates when Menu is visible
        /// </summary>
        public bool MenuVisible
        {
            get
            {
                return _menu.activeSelf;
            }
            set
            {
                if (value)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;

                _menu.SetActive(value);
            }
        }

        public UIElems()
        {
            _buttonsDic = new Dictionary<ButtonsName, Button>();

            _menu = GameObject.FindGameObjectWithTag(Tags.MenuGroupTag);

            _buttonsDic.Add(ButtonsName.Back, GameObject.FindGameObjectWithTag(Tags.MenuBtnBackTag).GetComponent<Button>());
            _buttonsDic.Add(ButtonsName.Exit, GameObject.FindGameObjectWithTag(Tags.MenuBtnExitTag).GetComponent<Button>());
            _buttonsDic.Add(ButtonsName.Load, GameObject.FindGameObjectWithTag(Tags.MenuBtnLoadTag).GetComponent<Button>());
            _buttonsDic.Add(ButtonsName.OK, GameObject.FindGameObjectWithTag(Tags.MenuBtnOKTag).GetComponent<Button>());
            _buttonsDic.Add(ButtonsName.Restart, GameObject.FindGameObjectWithTag(Tags.MenuBtnRestartTag).GetComponent<Button>());
            _buttonsDic.Add(ButtonsName.Save, GameObject.FindGameObjectWithTag(Tags.MenuBtnSaveTag).GetComponent<Button>());

            _menuText = GameObject.FindGameObjectWithTag(Tags.MenuTextTag).GetComponent<TextMeshProUGUI>();
            
            _menuText.text = "Game in pause mode";

            HideAllButtons();
            ChangeButtonVisible(ButtonsName.Load, true);
            ChangeButtonVisible(ButtonsName.Save, true);
            ChangeButtonVisible(ButtonsName.Exit, true);
            _menu.SetActive(false);

            _textMeshHealth = GameObject.FindGameObjectWithTag(Tags.HealthUITag).GetComponent<TextMeshProUGUI>();
            _textMeshSpeed = GameObject.FindGameObjectWithTag(Tags.SpeedUITag).GetComponent<TextMeshProUGUI>();
            _textMeshWin = GameObject.FindGameObjectWithTag(Tags.WinUITag).GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// Set active to false for all buttons
        /// </summary>
        public void HideAllButtons()
        {
            foreach (Button item in _buttonsDic.Values)
            {
                item.transform.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Change visibility (its active state) for button
        /// </summary>
        /// <param name="buttonName">Button</param>
        /// <param name="visible">Is button visible</param>
        public void ChangeButtonVisible(ButtonsName buttonName, bool visible)
        {
            _buttonsDic[buttonName].transform.gameObject.SetActive(visible);
        }
    }
}