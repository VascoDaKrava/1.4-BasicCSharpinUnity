using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kravchuk
{
    public class UIButtonsClickHandler : MonoBehaviour
    {
        public UIElems ElemsUI { get; set; }
        public DataSaveLoadRepo DataSaveLoadLink { get; set; }

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
            DataSaveLoadLink.Save();
            ElemsUI.ChangeButtonEnableState(ButtonsName.Load, true);
        }

        public void onClickLoad()
        {
            DataSaveLoadLink.Load();
        }
    }
}