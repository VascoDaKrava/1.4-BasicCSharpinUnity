using UnityEngine;

namespace Kravchuk
{
    public sealed class PlayerView
    {
        /// <summary>
        /// Color for reaction if collected good bonus
        /// </summary>
        private Color _colorGoodValue = Color.green;

        /// <summary>
        /// Color for reaction if collected bad bonus
        /// </summary>
        private Color _colorBadValue = Color.red;

        /// <summary>
        /// Normal text color
        /// </summary>
        private Color _colorNormalValue = Color.white;

        private UIElements _elementsUI;

        /// <summary>
        /// Time in seconds to apply good/bad color
        /// </summary>
        private float _timeToChangeBasic = 1f;

        private float _elapsedTimeForHealth = 0f;
        private float _elapsedTimeForSpeed = 0f;

        private float _normalSpeed;

        public PlayerView(UIElements uIElements)
        {
            _elementsUI = uIElements;
            _normalSpeed = 0f;
        }

        /// <summary>
        /// Change health
        /// </summary>
        /// <param name="health"></param>
        /// <param name="isDecrease">Decrease or increace</param>
        public void ChangeHealth(int health, bool isDecrease)
        {
            if (isDecrease)
                _elementsUI.HealthTextColor = _colorBadValue;
            else
                _elementsUI.HealthTextColor = _colorGoodValue;

            _elapsedTimeForHealth = _timeToChangeBasic;

            _elementsUI.HealthTextValue = $"{health:D3}";
        }

        /// <summary>
        /// Change speed, set normal values
        /// </summary>
        /// <param name="speed"></param>
        public void ChangeSpeed(float speed)
        {
            _normalSpeed = speed;
            _elementsUI.SpeedTextValue = $"{speed:F1}";
            _elapsedTimeForSpeed = _timeToChangeBasic;
        }

        /// <summary>
        /// Change speed due duration
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="duration"></param>
        public void ChangeSpeed(float speed, float duration)
        {
            _elementsUI.SpeedTextValue = $"{_normalSpeed + speed:F1} ({duration:F0}s)";
            _elapsedTimeForSpeed = duration;
            if (speed < 0)
                _elementsUI.SpeedTextColor = _colorBadValue;
            else
                _elementsUI.SpeedTextColor = _colorGoodValue;
        }

        /// <summary>
        /// Message to log
        /// </summary>
        /// <param name="message"></param>
        public void ServiceMessage(string message)
        {
            Debug.Log(message);
        }

        /// <summary>
        /// Calculating time for color effect.
        /// This method need to put in Update
        /// </summary>
        public void ForTime()
        {
            if (_elapsedTimeForHealth > 0)
                _elapsedTimeForHealth -= Time.deltaTime;
            else
                _elementsUI.HealthTextColor = _colorNormalValue;

            if (_elapsedTimeForSpeed > 0)
                _elapsedTimeForSpeed -= Time.deltaTime;
            else
            {
                _elementsUI.SpeedTextColor = _colorNormalValue;
                _elementsUI.SpeedTextValue = $"{_normalSpeed:F1}";
            }
        }
    }
}