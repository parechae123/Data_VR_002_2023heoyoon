using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ListExample : MonoBehaviour
{
    public List<int> numberA = new List<int>();
    public List<int> numberB = new List<int>();
    public List<int> except = new List<int>();
    public List<int> intersect = new List<int>();
    public List<int> union = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        numberA.Add(1);
        numberA.Add(2);
        numberA.Add(5);
        numberA.Add(8);

        numberB.Add(1);
        numberB.Add(3);
        numberB.Add(5);
        numberB.Add(7);
        numberB.Add(9);

        except = numberA.Except(numberB).ToList();

        intersect = numberA.Intersect(numberB).ToList();

        union = numberA.Union(numberB).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
