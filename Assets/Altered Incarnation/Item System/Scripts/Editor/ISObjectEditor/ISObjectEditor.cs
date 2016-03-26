using UnityEditor;
using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        [MenuItem("AltInc/Database/Item Editor %#i")]
        public static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.minSize = new Vector2(800, 600);

            // TODO:  Icon/tooltip
            window.titleContent.text = "Item DB";

            window.Show();
        }

        void OnEnable()
        {
        }

        void OnGUI()
        {
            TopTabBar();
            ListView();
        }
    }
}