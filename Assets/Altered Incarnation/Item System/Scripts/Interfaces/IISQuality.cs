using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem
{
    /// <summary>
    /// Item Quality Interface
    /// </summary>
    public interface IISQuality
    {
        /// <summary>
        /// Item Quality name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 2D icon to represent quality
        /// </summary>
        Sprite Icon { get; set; }
    }
}
