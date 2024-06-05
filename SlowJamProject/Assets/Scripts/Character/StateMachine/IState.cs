using System;
using UnityEngine;

public interface IState
{
    public void EnterState() {}
    public void UpdateState() {}
    public void FixedUpdateState() {}
    public void ExitState() {}
}