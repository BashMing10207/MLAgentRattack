using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GetCompoParent : MonoBehaviour,IGetTagable
{
    protected Dictionary<Type, IGetCompoable> _components;

    [SerializeField]
    protected List<string> _tags = new List<string>();

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IGetCompoable>();

        List<IGetCompoable> list = GetComponentsInChildren<IGetCompoable>(true)
    .ToList();
        AddComponentToDictionary(ComponentInitialize(list));

        AfterInitialize(list);
    }

    private void AddComponentToDictionary(List<IGetCompoable> list)
    {
        list.ForEach(component => _components.TryAdd(component.GetType(), component));
    }

    private List<IGetCompoable> ComponentInitialize(List<IGetCompoable> list)
    {
        list.ForEach(component => component.Initialize(this));
        return list;
        //_components.Values.ToList().ForEach(component => component.Initialize(this));
    }

    protected virtual void AfterInitialize(List<IGetCompoable> list)
    {
        list.OfType<IAfterInitable>()
            .ToList().ForEach(afterInitable => afterInitable.AfterInit());
    }

    public T GetCompo<T>(bool isDerived = false) where T : IGetCompoable
    {
        if (_components.TryGetValue(typeof(T), out var component))
        {
            return (T)component;
        }

        if (isDerived == false) return default;

        Type findType = _components.Keys.FirstOrDefault(type => type.IsSubclassOf(typeof(T)));
        if (findType != null)
            return (T)_components[findType];

        return default;
    }

    public void AddTag(string tag)
    {
       if(!_tags.Contains(tag))
        {
            _tags.Add(tag);
        }
    }

    public bool HasTag(string tag)
    {
       return _tags.Contains(tag);
    }

    public void RemoveTag(string tag)
    {
        if(_tags.Contains(tag))
        {
            _tags.Remove(tag);
        }
    }
}


