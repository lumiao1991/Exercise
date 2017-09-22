using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHappyHouse
{
    //继承自Location类
    class Room:Location
    {
        //构造函数
        public Room(string name,string decoration)
            :base(name)//每次实例化子类的时候，都要调用基类的构造函数
        {
            this.decoration = decoration;
        }

        //装饰，私有字段
        private string decoration;

        //重写基类Description属性
        public override string Description
        {
            get
            {
                return base.Description + " 你能看到 " + decoration + ".";
            }
        }
    }
}
