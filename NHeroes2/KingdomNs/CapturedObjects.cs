﻿using System.Collections.Generic;
using NHeroes2.MapsNs;
using NHeroes2.Utilities;

namespace NHeroes2.KingdomNs
{
    internal class CapturedObjects
    {
        public Dictionary<int, CapturedObject> Items { get; } = new Dictionary<int, CapturedObject>();

        public void Set(int index, ObjKind obj, ColorKind col)
        {
            var co = Items.Set(index);


            if (co.GetColor() != col && co.guardians.IsValid())
                co.guardians.Reset();

            co.Set(obj, col);
        }

        public void SetColor(int index, ColorKind col)
        {
            Items.Set(index).SetColor(col);
        }
    }
}