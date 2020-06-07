using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected readonly BattleFSM _system;

    public State(BattleFSM system)
    {
        _system = system;
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Attack()
    {
        yield break;
    }
    public virtual IEnumerator Heal()
    {
        yield break;
    }
    public virtual IEnumerator Pause()
    {
        yield break;
    }
    public virtual IEnumerator Resume()
    {
        yield break;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
