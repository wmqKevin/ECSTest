using System;
using Unity.Entities;

[Serializable]
public struct MoveSpeed : IComponentData
{
    public float speed;
}

public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed> { } 