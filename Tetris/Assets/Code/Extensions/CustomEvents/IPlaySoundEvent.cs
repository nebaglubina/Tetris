using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class IPlaySoundEvent : IEvent
{
   private string _name;
   private bool _isLoop = false;

   public string Name => _name;

   public bool IsLoop => _isLoop;

   public IPlaySoundEvent(string name, bool isLoop = false)
   {
      _isLoop = isLoop;
      _name = name;
   }
}
