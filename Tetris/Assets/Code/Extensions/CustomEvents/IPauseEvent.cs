using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPauseEvent : IEvent
{
    private bool _doPause;

    public bool DoPause => _doPause;

    public IPauseEvent(bool doPause)
    {
        _doPause = doPause;
    }
}
