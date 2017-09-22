using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHappyHouse
{
    //表示有外门的房间
    interface IHasExteriorDoor
    {
        //只读属性，包含关于门的描述
        string DoorDescription { get; }

        //包含这个门所通向的location的引用
        Location DoorLocation { get; set; }
    }
}
