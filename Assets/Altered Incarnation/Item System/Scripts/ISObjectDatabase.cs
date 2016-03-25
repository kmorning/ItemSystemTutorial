using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem
{
    public class ISObjectDatabase : ScriptableObjectDatabase<ISObject>
    {
        public static ISObjectDatabase LoadDatabase(string dbPath, string dbName)
        {
            return LoadDatabase<ISObjectDatabase>(dbPath, dbName);
        }
    }
}
