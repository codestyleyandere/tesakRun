using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChange += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChange -= OnHealthChanged;
    }
    private void OnHealthChanged (int value)
    {
        if(_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;
            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            int deleteHealth = _hearts.Count - value;
            for (int i = 0; i < deleteHealth; i++)
            {
                DestroyHearth(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHearth(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();  
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}