using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimal : NewMonoBehaviour
{
    [SerializeField] protected SO_CHECKANIMAL sO_CHECKANIMAL;
    [SerializeField] protected SO_INDEX sO_INDEX;
    private Dictionary<Transform, Coroutine> coroutineDictionary = new Dictionary<Transform, Coroutine>();
    [SerializeField] protected Transform Holder;
    [SerializeField] private List<Transform> animalsInZone = new List<Transform>();
    [SerializeField] private float spacing = 2f;
    public float CountPoint;
    

    protected override void Start()
    {
        base.Start();
        this.CountPoint = 0;
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal") && !coroutineDictionary.ContainsKey(other.transform))
        {
            Coroutine newCoroutine = StartCoroutine(CountDown(other.transform));
            coroutineDictionary.Add(other.transform, newCoroutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Animal") && coroutineDictionary.ContainsKey(other.transform))
        {
            StopCoroutine(coroutineDictionary[other.transform]);
            coroutineDictionary.Remove(other.transform);
        }
    }

    private IEnumerator CountDown(Transform animal)
    {
        float timer = 0f;
        while (timer < 3f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        if (!animalsInZone.Contains(animal))
        {
            animalsInZone.Add(animal);
            IncrementScore();
            ArrangeAnimalOnPlayer(animal);
        }
        coroutineDictionary.Remove(animal);
    }
    private void IncrementScore()
    {
        CountPoint += 100;
    }

    private void ArrangeAnimalOnPlayer(Transform animal)
    {
        animal.SetParent(Holder);
        RearrangeAnimals();
    }
    private void RearrangeAnimals()
    {
        for (int i = 0; i < animalsInZone.Count; i++)
        {
            Transform animal = animalsInZone[i];
            float currentHeight = i * spacing;
            animal.localPosition = new Vector3(0, currentHeight, 0);
            animal.localRotation = Quaternion.identity;
        }
    }
}
