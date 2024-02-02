using UnityEngine;

namespace Homework2_2Task_2
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HudController _hud;
        [SerializeField] private RestartMenuController _restartMenu;
        [SerializeField] private Player _player;
        [SerializeField] private Mediator _mediator;

        void Awake()
        {
            _hud.Initialize();
            _restartMenu.Initialize();
            _player.Initialize();
            _mediator.Initialize();

            Application.targetFrameRate = 60;
        }
    }
}