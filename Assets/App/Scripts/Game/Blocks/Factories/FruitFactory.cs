using UnityEngine;

public class FruitFactory : BlockFactory
{
    public override Block Create()
    {
        GameObject obj = new GameObject("Fruit");

        obj.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Block Sprites/1");

        return obj.AddComponent<Fruit>();
    }
}
