using UnityEditor;
using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem.Editor
{
    /// <summary>
    /// Quality Database Editor Window
    /// </summary>
    public partial class ISQualityDatabaseEditor : EditorWindow
    {
        ISQualityDatabase qualityDB;
        ISQuality selectedItem;
        Texture2D selectedTexture;

        Vector2 _scrollPos; // scroll view for ListView

        const string DB_FILE = "aiQualityDatabase.asset";
        const string DB_FOLDER_NAME = "Database";
        const string DB_PATH = @"Assets/" + DB_FOLDER_NAME + @"/" + DB_FILE;

        const int SPRITE_BUTTON_SIZE = 46;

        [MenuItem("AltInc/Database/Quality Editor %#i")]
        public static void Init()
        {
            ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            window.minSize = new Vector2(400, 300);
            //window.title = "Quality Database";  // deprecated

            // TODO:  Icon/tooltip
            window.titleContent.text = "Quality DB";

            window.Show();
        }

        void OnEnable()
        {
            qualityDB = ISQualityDatabase.LoadDatabase(DB_FOLDER_NAME, DB_FILE);

            /*
            qualityDB = AssetDatabase.LoadAssetAtPath(DB_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

            if (qualityDB == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + DB_FOLDER_NAME))
                {
                    AssetDatabase.CreateFolder("Assets", DB_FOLDER_NAME);
                }
                qualityDB = ScriptableObject.CreateInstance<ISQualityDatabase>();
                AssetDatabase.CreateAsset(qualityDB, DB_PATH);
                AssetDatabase.SaveAssets();
                //AssetDatabase.Refresh();
            }
            selectedItem = new ISQuality();
             */
        }

        void OnGUI()
        {
            //GUILayout.Label("This is a label");
            //AddQualityToDataBase();
            ListView();

            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            BottomBar();
            GUILayout.EndHorizontal();
        }

        void BottomBar()
        {
            GUILayout.Label("Qualities: " + qualityDB.Items.Count);

            if (GUILayout.Button("Add"))
            {
                qualityDB.Items.Add(new ISQuality());
            }
        }

        void AddQualityToDataBase()
        {
            selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);

            if (selectedItem.Icon)
            {
                selectedTexture = selectedItem.Icon.texture;
            }
            else
            {
                selectedTexture = null;
            }

            if (GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
            {
                int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlID);
            }

            string commandName = Event.current.commandName;
            if (commandName == "ObjectSelectorUpdated")
            {
                selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                Repaint();
            }

            if (GUILayout.Button("Save"))
            {
                if (selectedItem == null || string.IsNullOrEmpty(selectedItem.Name)) return;

                //qualityDB.Add(selectedItem);
                qualityDB.Items.Add(selectedItem);
                EditorUtility.SetDirty(qualityDB);
                selectedItem = new ISQuality();
            }
        }
    }
}