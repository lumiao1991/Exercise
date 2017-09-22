using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHappyHouse
{
    //基类
    class Location
    {
        //构造函数
        public Location(string name)
        {
            Name = name;
        }

        //地点名称，只读属性
        public string Name { get; private set; }

        //Location对象数组，表示当前位置连接到哪些位置
        public Location[] Exits;

        //该地点的描述，只读属性
        public virtual string Description
        {
            get
            {
                string description = "你现在正站在"+Name+".你能通往：";

                for (int i = 0; i < Exits.Length; i++)
                {
                    description +=" "+Exits[i].Name;
                    if (i != Exits.Length - 1)
                        description += ",";
                }
                description += ".";
                return description;
            }
        }
    }
}
