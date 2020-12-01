
using Zenject;

public interface IInputManager : ITickable
{
     bool IsActive { get; set; }
     void Tick();
}
