using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class BattleFSM : MonoBehaviour
{
    public enum BattleFSM_States { Begin, WON, LOSS, PlayerTurn, EnemyTurn };

    private Unit PlayerUnit;
    private Unit enemyunit;
    private BattleFSM_States state;
    private BattleFSM_States prievious;


    [SerializeField] private GameObject playerprefab;
    [SerializeField] private GameObject enemyprefab;
    [SerializeField] private Transform playerposition;
    [SerializeField] private Transform enemyposition;



    private State _currentstate;

    public void OnResumeButton()
    {
       // if(state!=BattleFSM_States.Begin)
    }

    public void setState(State state)
    {
        _currentstate = state;
        StartCoroutine(_currentstate.Start());
    }

    public void SetupBattle()
    {
        var playerGameObject = Instantiate(playerprefab, playerposition);
        PlayerUnit = playerGameObject.GetComponent<Unit>();

        var enemyGameObject = Instantiate(enemyprefab, enemyposition);
        enemyunit= enemyGameObject.GetComponent<Unit>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
