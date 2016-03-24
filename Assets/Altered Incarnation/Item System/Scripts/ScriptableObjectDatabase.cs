using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace AlteredIncarnation
{
    public class ScriptableObjectDatabase<T> : ScriptableObject where T: class
    {
        [SerializeField]
        List<T> _items = new List<T>();

        public List<T> Items
        {
            get { return _items; }
        }

        protected static U LoadDatabase<U>(string dbPath, string dbName) where U: ScriptableObject
        {
            string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

            U db = AssetDatabase.LoadAssetAtPath<U>(dbFullPath);
            
            if (db == null)
            {
                // check if folder exists
                if (!AssetDatabase.IsValidFolder(@"Assets/" + dbPath))
                {
                    AssetDatabase.CreateFolder(@"Assets", dbPath);
                }

                // create teh database and refresh the AssetDatabase
                db = ScriptableObject.CreateInstance<U>();
                AssetDatabase.CreateAsset(db, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            return db;
        }
    }
}