﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6010 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Person person)
        {
            if (this.increment > person.InfluenceIncrementOfStrength)
            {
                person.InfluenceIncrementOfStrength += this.increment;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.InfluenceIncrementOfStrength -= this.increment;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

