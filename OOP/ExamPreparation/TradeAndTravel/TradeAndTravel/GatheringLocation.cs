using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        public GatheringLocation(string name, ItemType gatheredItemType, ItemType requiredItemType)
            : base(name, LocationType.Forest)
        {
            this.GatheredType = gatheredItemType;
            this.RequiredItem = requiredItemType;
        }

        public ItemType GatheredType { get; private set; }

        public ItemType RequiredItem { get; private set; }

        public abstract Item ProduceItem(string name);
    }
}
