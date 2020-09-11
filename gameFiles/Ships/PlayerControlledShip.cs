using Godot;
using System;

public class PlayerControlledShip : Area2D
{
    private Vector2 velocity = new Vector2(0,0);

    /// <summary>
    /// Acceleration value to be applied to the velocity   
    /// </summary>
    /// <value>m*s^2 min value: 0</value>
    [Export]
    public float Acceleration {get;set;}

    /// <summary>
    /// MaxVelocity the ship can have
    /// </summary>
    /// <value>m*s min value: 0</value>
    [Export]
    public float MaxVelocity {get; set;} = 666;

    /// <summary>
    /// Deceleration value to be applied to the velocity   
    /// </summary>
    /// <value>m*s^2 min value: 0</value>
    [Export]
    public float Deceleration { get;set; }

    private void accelerate(Vector2 direction, float deltaSecs, float force){
        
        velocity.x = Math.Min( velocity.x + (  direction.x * Acceleration * deltaSecs * force), MaxVelocity);
        velocity.y = Math.Min( velocity.y + (  direction.y * Acceleration * deltaSecs * force), MaxVelocity);
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Input.IsActionPressed("ui_up")){
            accelerate(Vector2.Up,delta,Input.GetActionStrength("ui_up"));
        }
        if(Input.IsActionPressed("ui_down")){
            accelerate(Vector2.Down,delta,Input.GetActionStrength("ui_down"));
        }
        if(Input.IsActionPressed("ui_right")){
            accelerate(Vector2.Right,delta,Input.GetActionStrength("ui_right"));
        }
        if(Input.IsActionPressed("ui_left")){
            accelerate(Vector2.Left,delta,Input.GetActionStrength("ui_left"));
        }

/*
        var newVelocity = velocity  + ( velocity.Normalized() * velocity.Sign() * Deceleration);
        velocity.x = Math.Max(0, newVelocity.x);
        velocity.y = Math.Max(0, newVelocity.y);*/
        Position = Position + (velocity * delta);
        
    }
}
