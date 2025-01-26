using Patterns.Command.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Command.Commands;
using UnityEngine.Assertions;

namespace Patterns.Command.Components
{
    public class InputManager : MonoBehaviour
    {

        private IPlayerReceiver _currentPlayer;
        private IArmaReceiver _arma;
        private IUIReceiver _ui;
        private CommandManager _commandManager;

        public void Awake()
        {
            _commandManager = new CommandManager();

            GameObject player = GameObject.FindWithTag("Player");

            _currentPlayer = player.GetComponent<IPlayerReceiver>();

            GameObject arma = GameObject.FindWithTag("Arma");

            _arma = arma.GetComponent<IArmaReceiver>();

            GameObject ui = GameObject.FindWithTag("Ajustes");

            _ui = ui.GetComponent<IUIReceiver>();


        }

        private void Update()
        {
            if (Time.timeScale != 0f)
            {
                //Player commands
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ICommand command = new MoveUp(_currentPlayer);
                    _commandManager.ExecuteCommand(command);
                }

                if (Input.GetButton("Horizontal"))
                {
                    float x = Input.GetAxis("Horizontal");
                    ICommand command = new Move(_currentPlayer, x);
                    _commandManager.ExecuteCommand(command);
                }

                if (Input.GetButton("Vertical"))
                {
                    ICommand command = new MoveForward(_currentPlayer, Input.GetAxis("Vertical"));
                    _commandManager.ExecuteCommand(command);
                }

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    ICommand command = new Sprint(_currentPlayer);
                    _commandManager.ExecuteCommand(command);
                }

                //Arma commands
                if (Input.GetButton("Fire1"))
                {
                    ICommand command = new ShootCommand(_arma);
                    _commandManager.ExecuteCommand(command);
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    ICommand command = new ReloadCommand(_arma);
                    _commandManager.ExecuteCommand(command);
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ICommand command = new AjustesCommand(_ui);
                    _commandManager.ExecuteCommand(command);
                }
            }

        }
    }

}
