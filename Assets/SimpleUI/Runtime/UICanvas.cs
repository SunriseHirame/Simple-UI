using UnityEngine;

namespace SunriseHirame.SimpleUI
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] private string canvasId = "Default";
        public string Id => canvasId;

        private void OnEnable ()
        {
            UICanvasDatabase.RegisterActiveCanvas (this);
        }

        private void OnDisable ()
        {
            UICanvasDatabase.UnregisterActiveCanvas (this);
        }
    }

}