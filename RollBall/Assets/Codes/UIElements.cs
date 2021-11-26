using TMPro;
using UnityEngine;

namespace Kravchuk
{
    public sealed class UIElements
    {
        private TextMeshProUGUI _textMeshHealth;
        private TextMeshProUGUI _textMeshSpeed;
        private TextMeshProUGUI _textMeshWin;

        public string HealthTextValue {
            set
            {
                _textMeshHealth.text = value;   
            }
        }

        public Color HealthTextColor { 
            set
            {
                _textMeshHealth.color = value;
            }
        }

        public string SpeedTextValue {
            set
            {
                _textMeshSpeed.text = value;
            }
        }

        public Color SpeedTextColor
        {
            set
            {
                _textMeshSpeed.color = value;
            }
        }

        public string WinTextValue {
            set
            {
                _textMeshWin.text = value;
            }
        }

        public UIElements()
        {
            _textMeshHealth = GameObject.FindGameObjectWithTag(StaticValues.TagHealthUI).GetComponent<TextMeshProUGUI>();
            _textMeshSpeed = GameObject.FindGameObjectWithTag(StaticValues.TagSpeedUI).GetComponent<TextMeshProUGUI>();
            _textMeshWin = GameObject.FindGameObjectWithTag(StaticValues.TagWinUI).GetComponent<TextMeshProUGUI>();
        }
    }
}