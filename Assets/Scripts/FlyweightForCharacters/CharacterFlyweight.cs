using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FlyweightForCharacters
{
    public class CharacterFlyweight
    {
        public string Name { get;}

        public CharacterFlyweight(string name)
        {
            Name = name;
        }
    }
}
