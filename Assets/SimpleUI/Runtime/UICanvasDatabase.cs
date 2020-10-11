using System.Collections.Generic;

namespace SunriseHirame.SimpleUI
{
    public static class UICanvasDatabase
    {
        private static readonly Dictionary<string, UICanvas> CanvasMap = new Dictionary<string, UICanvas> ();

        public static bool TryGetUICanvas (string id, out UICanvas uiCanvas)
        {
            return CanvasMap.TryGetValue (id, out uiCanvas) && uiCanvas;
        }
        
        internal static void RegisterActiveCanvas (UICanvas uiCanvas)
        {
            CanvasMap[uiCanvas.Id] = uiCanvas;
        }

        internal static void UnregisterActiveCanvas (UICanvas uiCanvas)
        {
            CanvasMap.Remove (uiCanvas.Id);
        }
    }

}