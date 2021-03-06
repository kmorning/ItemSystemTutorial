﻿using UnityEngine;
using System.Collections;

namespace AlteredIncarnation.ItemSystem
{
    public interface IISEquipmentSlot
    {
        string Name { get; set; }
        Sprite Icon { get; set; }
    }
}