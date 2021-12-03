using UnityEngine;

namespace Kravchuk
{
    /// <summary>
    /// Container for constants like string values
    /// </summary>
    public static class StaticValues
    {

        public const string PickupParentName = "PickUps";

        #region Resources

        public const string ResourcePickupHealth = "PickupHealth";
        public const string ResourcePickupSpeed = "PickupSpeed";
        public const string ResourcePickupWin = "PickupWin";

        #endregion

        #region Tags

        public const string GameControllerTag = "GameController";
        public const string PlayerTag = "Player";
        public const string CameraTag = "MainCamera";

        public const string HealthUITag = "TagHealthUI";
        public const string SpeedUITag = "TagSpeedUI";
        public const string WinUITag = "TagWinUI";

        public const string MenuGroupTag = "TagMenuUI";
        public const string MenuBtnRestartTag = "TagBtnRestart";
        public const string MenuBtnSaveTag = "TagBtnSave";
        public const string MenuBtnLoadTag = "TagBtnLoad";
        public const string MenuBtnOKTag = "TagBtnOK";
        public const string MenuBtnBackTag = "TagBtnBack";
        public const string MenuBtnExitTag = "TagBtnExit";
        public const string MenuTextTag = "TagMenuText";

        #endregion

        #region Keys and axises

        public const string ButtonStop = "Stop";
        public const KeyCode ButtonFive = KeyCode.Alpha5;

        public const string AxisHorizontal = "Horizontal";
        public const string AxisVertical = "Vertical";

        #endregion
    }
}