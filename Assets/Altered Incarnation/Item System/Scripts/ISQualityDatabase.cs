using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlteredIncarnation.ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
        public static ISQualityDatabase LoadDatabase(string dbPath, string dbName)
        {
            return LoadDatabase<ISQualityDatabase>(dbPath, dbName);
        }
        /*
        [SerializeField]
        List<ISQuality> _items = new List<ISQuality>();

        public List<ISQuality> Items
        {
            //get { return db.AsReadOnly(); }
            get { return _items; }
        }
        */

        /*  I rather use the normal List methods here instead
        public void Add(ISQuality item)
        {
            db.Add(item);
        }

        public void Insert(int index, ISQuality item)
        {
            db.Insert(index, item);
        }

        public void Remove(ISQuality item)
        {
            db.Remove(item);
        }

        public void Remove(int index)
        {
            db.RemoveAt(index);
        }

        public int Count
        {
            get { return db.Count; }
        }

        public ISQuality Get(int index)
        {
            return db.ElementAt(index);
        }

        public void Replace(int index, ISQuality item)
        {
            db[index] = item;
        }
      */
    }
}