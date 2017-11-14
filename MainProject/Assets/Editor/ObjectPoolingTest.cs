using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class ObjectPoolingTest
{
    [Test]
    public void InventoryFromNothing()
    {
        int targetCount = 3;
        GameObject obj = GameObject.Find("InventoryPool");
        InventoryPooling pool = obj.GetComponent<InventoryPooling>();

        pool.LoadItems(targetCount);

        Assert.AreEqual(pool.ObjectCount, targetCount);
    }

    [Test]
    public void InventoryLoadMore()
    {
        int targetCount = 3;
        int secondTarget = 5;

        GameObject obj = GameObject.Find("InventoryPool");
        InventoryPooling pool = obj.GetComponent<InventoryPooling>();

        pool.LoadItems(targetCount);
        Assert.AreEqual(pool.ObjectCount, targetCount);
        pool.LoadItems(secondTarget);

        Assert.AreEqual(pool.ObjectCount, secondTarget);
    }

    [Test]
    public void InventoryLoadLess()
    {
        int initialCount = 5;
        int targetCount = 2;

        GameObject obj = GameObject.Find("InventoryPool");
        InventoryPooling pool = obj.GetComponent<InventoryPooling>();

        pool.LoadItems(initialCount);
        Assert.AreEqual(pool.ObjectCount, initialCount);

        pool.LoadItems(targetCount);

        Assert.AreEqual(pool.ObjectCount, targetCount);
    }
}
