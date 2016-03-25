using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        void TopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            GUILayout.Button("Weapons");
            GUILayout.EndHorizontal();
        }
    }
}
