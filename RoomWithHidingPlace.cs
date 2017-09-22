using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHappyHouse
{
    class RoomWithHidingPlace:Room,IHidingPlace
    {
        public RoomWithHidingPlace(string name,string decoration,string hidingPlaceName)
            :base(name,decoration)
        {
            HidingPlaceName = hidingPlaceName;
        }

        public string HidingPlaceName { get; private set; }

        public override string Description
        {
            get
            {
                return base.Description + "可能有人藏在" + HidingPlaceName + ".";
            }
        }
    }
}
