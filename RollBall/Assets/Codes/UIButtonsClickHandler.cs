using UnityEngine;

namespace Kravchuk
{
    public class UIButtonsClickHandler : MonoBehaviour
    {
        public void onClickOK()
        {
            Debug.Log("Press OK");
        }

        public void onClickBack()
        {
            Debug.Log("Press Back");
        }

        public void onClickExit()
        {
            Debug.Log("Press Exit");
        }

        public void onClickRestart()
        {
            Debug.Log("Press Restart");
        }

        public void onClickSave()
        {
            Debug.Log("Press Save");
        }

        public void onClickLoad()
        {
            Debug.Log("Press Load");
        }
    }
}