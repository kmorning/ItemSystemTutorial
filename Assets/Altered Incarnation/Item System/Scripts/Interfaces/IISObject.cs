using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem
{
    /// <summary>
    /// Item System Interface
    /// </summary>
    public interface IISObject
    {
        /// <summary>
        /// Name of the item.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Value of the item based on whatever monetary units we choose for the game.
        /// </summary>
        int Value { get; set; }

        /// <summary>
        /// Icon used to represent the item in a 2D depiction.
        /// </summary>
        Sprite Icon { get; set; }

        /// <summary>
        /// Represents the amount of burden an item incurs (usually when carrying), and will probably be
        /// a representation of weight.
        /// </summary>
        int Burden { get; set; }

        /// <summary>
        /// Item quality
        /// </summary>
        ISQuality Quality { get; set; }

        /* TODO:
         * equip
         * questItem flag
         * prefab
         */
    }
}
