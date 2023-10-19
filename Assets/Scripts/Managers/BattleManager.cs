using System.Collections;
using System.Collections.Generic;
using CustomController;

public class BattleManager : Singleton<BattleManager>
{
    public CharacterController playerController;

    public List<CharacterController> enemyCollection;

    private void Awake()
    {
        enemyCollection = new List<CharacterController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
