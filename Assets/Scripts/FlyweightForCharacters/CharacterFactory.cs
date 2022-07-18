using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FlyweightForCharacters
{
    public class CharacterFactory
    {
        public List<CharacterFlyweight> Flyweights { get; set; }
        private static CharacterFactory _instance;
        private static readonly object padlock = new();

        public static CharacterFactory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new CharacterFactory();
                    }
                }
                return _instance;
            }
        }
        private CharacterFactory()
        {
            Flyweights = new List<CharacterFlyweight>();
        }
        public Character CreateCharacter(string name)
        {
            CharacterFlyweight flyweight = GetCharacterFlyweight(name);
            Character character = new Character(flyweight);
            character.Speed = 4f;
            return character;
        }
        private CharacterFlyweight GetCharacterFlyweight(string name)
        {
            CharacterFlyweight characterFlyweight = Flyweights.Find(cf => cf.Name == name);
            if (characterFlyweight == null)
            {
                characterFlyweight = new CharacterFlyweight(name);
                Flyweights.Add(characterFlyweight);
            }
            return characterFlyweight;
        }
    }
}
