﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6585 : InfluenceKind
    {
        private int rate = 0;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.TirednessIncreaseOnCritical += this.rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.TirednessIncreaseOnCritical -= this.rate;
        }
    }
}

