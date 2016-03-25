using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlteredIncarnation.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor
    {
        /// <summary>
        /// List all of the stored qualities in the database.
        /// </summary>
        void ListView()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));

            DisplayQualities();

            EditorGUILayout.EndScrollView();
        }

        void DisplayQualities()
        {
            int removeIndex = -1;
            List<string> nameEdits = new List<string>();

            foreach (ISQuality item in qualityDB.Items)
            {
                GUILayout.BeginHorizontal("Box");
                // Sprite
                Texture2D texture = null;
                if (item.Icon)
                {
                    texture = item.Icon.texture;
                }
                if (GUILayout.Button(texture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
                {
                    int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlID);
                    selectedItem = item;
                }

                // Item Name
                string itemName;
                itemName = GUILayout.TextField(item.Name);
                nameEdits.Add(itemName);

                // Delete Button
                if (GUILayout.Button("x", GUILayout.Width(30)))
                {
                    if (EditorUtility.DisplayDialog("Delete Quality", 
                        "Are you sure that you want to delete " + item.Name + 
                        " from the database?", "Delete", "Cancel"))
                    {
                        removeIndex = qualityDB.Items.IndexOf(item);
                        EditorUtility.SetDirty(qualityDB);
                    }
                }
                GUILayout.EndHorizontal();
            }

            
            // Handle item name change
            foreach (ISQuality item in qualityDB.Items)
            {
                if (item.Name != nameEdits[qualityDB.Items.IndexOf(item)])
                {
                    item.Name = nameEdits[qualityDB.Items.IndexOf(item)];
                    EditorUtility.SetDirty(qualityDB);
                }
            }

            // Handle icon change
            string commandName = Event.current.commandName;
            if (commandName == "ObjectSelectorUpdated")
            {
                selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                Repaint();
                EditorUtility.SetDirty(qualityDB);
            }

            // Remove pending deletion from list
            if (removeIndex >= 0)
            {
                qualityDB.Items.RemoveAt(removeIndex);
            }
        }
    }
}