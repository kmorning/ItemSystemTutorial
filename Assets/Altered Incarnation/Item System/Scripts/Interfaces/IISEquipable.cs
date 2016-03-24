using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem
{
    public interface IISEquipable
    {
        ISEquipmentSlot EquipmentSlot { get; }
        bool Equip();
    }
}