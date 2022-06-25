using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class IATransicion 
{
    public IADecision Decision;
    public IAEstado EstadoTrue;
    public IAEstado EstadoFalse;

}
