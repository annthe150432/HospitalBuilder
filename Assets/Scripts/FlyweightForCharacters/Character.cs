using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FlyweightForCharacters
{
    public class Character
    {
        public float Speed { get; set; }
        public CharacterFlyweight CharacterFlyweight { get; }

        public Character(CharacterFlyweight characterFlyweight)
        {
            CharacterFlyweight = characterFlyweight;
        }
    }
}
