using Cainos.LucidEditor;
using System;
using UnityEngine;
using UnityEngine.Events;

public class PropsInteractionController : MonoBehaviour
{
    [SerializeField] private Props PropData;
    [SerializeField] private Collider2D propCollider;
    [SerializeField] private Rigidbody2D rb;
    


    private void Awake()
    {
        InitProp();
    }

   

    private void InitProp()
    {
        GameObject propSprite = Instantiate(PropData.propSpritePrefab, transform.position, Quaternion.identity);
        propSprite.transform.SetParent(transform);
        this.name = PropData.propName;
        propSprite.transform.localScale = Vector3.one;
        propSprite.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Foreground");
        propCollider = GetComponentInChildren<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log($"Player has entered collision with {PropData.propName}");
            PropData.OnPlayerEnter?.Invoke();
        }
        else
        {
            Debug.Log($"Other object has entered collision with {PropData.propName}, {collision.gameObject.tag}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Player has entered collision with {PropData.propName}");
            PropData.OnPlayerExit?.Invoke();

        }
        else
        {
            Debug.Log($"Other object has entered collision with {PropData.propName}, {collision.gameObject.tag}");
        }
    }

}
