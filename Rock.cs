using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ZuulCS;

namespace ZuulCS {
    

    class Rock : Item{

        public Rock(string name, int weight) : base(name, weight) {
            description = "A rock the perfect size for throwing";
        }
    }
}
