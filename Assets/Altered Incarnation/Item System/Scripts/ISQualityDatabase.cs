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
    }
}