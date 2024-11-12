using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : ICommand
{
    private PlayerController _controller;
        
    public MoveLeft (PlayerController controller)
    {
        _controller = controller;
    }
        
    public override void Execute()
    {
        _controller.Move(PlayerController.Direction.Left);
    }
}