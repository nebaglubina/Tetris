using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Installers/GameSettings")]
public class GameSettings : ScriptableObjectInstaller<GameSettings>
{
    public ScoreManager.Settings ScoreSettings;
    public GridManager.Settings GridSettings;
    public SpawnManager.Settings SpawnSettings;
    public override void InstallBindings()
    {
        Container.BindInstances(ScoreSettings, GridSettings, SpawnSettings);
    }
}