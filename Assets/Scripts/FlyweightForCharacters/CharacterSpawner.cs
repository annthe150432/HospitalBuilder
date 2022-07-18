using Assets.Scripts.FlyweightForCharacters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> characters;
    Vector3 spawnPosition;
    Timer timer;
    CharacterPathfindingMovementHandler movementHandler;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = gameObject.transform.position;
        //movementHandler = gameObject.AddComponent<CharacterPathfindingMovementHandler>();
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 8f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.Running)
        {
            CreateCharacterObject();
            timer.Run();
        }
    }
    void CreateCharacterObject()
    {
        int rand = Random.Range(0, characters.Count);
        GameObject characterGO = Instantiate<GameObject>(characters[rand]);
        characterGO.transform.position = spawnPosition;
        string name = characterGO.tag;
        Character character = CharacterFactory.Instance.CreateCharacter(name);


        movementHandler = characterGO.AddComponent<CharacterPathfindingMovementHandler>();
        movementHandler.speed = character.Speed;
    }

}
