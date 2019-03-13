using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class ECSTest : MonoBehaviour
{
    private static EntityManager EntityManager;

    private static EntityArchetype _entityArchetype;

    public GameObject prefab;
    public int SpawnCount;
    public float Speed;
    public bool UseECS;
    public MeshInstanceRenderer MeshInstanceRenderer;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialized()
    {
        EntityManager = World.Active.GetOrCreateManager<EntityManager>();
        _entityArchetype = EntityManager.CreateArchetype(typeof(Position), typeof(Rotation));
    }
    // Start is called before the first frame update
    void Start()
    {
//        Entity entity = EntityManager.CreateEntity(_entityArchetype);
//        EntityManager.SetComponentData(entity,new Position(){Value = float3.zero});
//        EntityManager.SetComponentData(entity,new Rotation(){Value = quaternion.Euler(0,45,0)});
//        EntityManager.AddComponentData(entity,new Scale(){Value = new float3(0.2f,0.2f,0.2f)});
//        EntityManager.AddSharedComponentData(entity,new MoveForward(){});
//        EntityManager.AddComponentData(entity,new MoveSpeed(){speed = Speed});
//        EntityManager.AddSharedComponentData(entity,MeshInstanceRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (UseECS)
            {
                SpawnEntities(SpawnCount);
            }
            else
            {
                SpawnGameObjects(SpawnCount);
            }
        }
    }

    public void SpawnEntities(int count)
    {
        float angle = 90f / count;
        for (int i = 0; i < count; i++)
        {
            Entity entity = EntityManager.CreateEntity(_entityArchetype);
            EntityManager.SetComponentData(entity,new Position(){Value = float3.zero});
            EntityManager.SetComponentData(entity,new Rotation(){Value = quaternion.Euler(0,i*angle,0)});
            EntityManager.AddComponentData(entity,new Scale(){Value = new float3(0.2f,0.2f,0.2f)});
            EntityManager.AddSharedComponentData(entity,new MoveForward(){});
            EntityManager.AddComponentData(entity,new MoveSpeed(){speed = Speed});
            EntityManager.AddSharedComponentData(entity,MeshInstanceRenderer);
        }
    }

    public void SpawnGameObjects(int count)
    {
        float angle = 180f / count;
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.Euler(0,i*angle,0));
            go.transform.localScale = Vector3.one*0.2f;
            
        }
    }
}
