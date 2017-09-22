using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHappyHouse
{
    class Outside:Location
    {
        //构造函数
        public Outside(string name,bool hot)
            :base(name)
        {
            this.hot = hot;
        }

        private bool hot;

        public override string Description
        {
            get
            {
                string newDescription = base.Description;
                if (hot)
                    newDescription += " 这里很热！";
                return newDescription;
            }
        }
    }
}
