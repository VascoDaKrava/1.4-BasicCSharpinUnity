using UnityEngine;

namespace Kravchuk
{
    public class PlayerView
    {
        public void ChangeHealth(int health)
        {
            Debug.Log($"New health : {health}");
        }

        public void ChangeSpeed(float speed)
        {
            Debug.Log($"Now speed = {speed:F2}");
        }

        public void ChangeSpeed(float speed, float duration)
        {
            Debug.Log($"Changing speed by {speed:F2}. Duration = {duration:F2}");
        }

        public void ServiceMessage(string message)
        {
            Debug.Log(message);
        }
    }
}