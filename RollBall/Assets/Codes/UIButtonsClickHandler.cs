using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kravchuk
{
    public class UIButtonsClickHandler : MonoBehaviour
    {
        public UIElems ElemsUI { get; set; }

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
            ElemsUI.HideAllButtons();
            ElemsUI.MenuVisible = false;
        }

        public void onClickRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ElemsUI.HideAllButtons();
            ElemsUI.MenuVisible = false;
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