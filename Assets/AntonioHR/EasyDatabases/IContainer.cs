using UnityEngine;
using System.Collections;


public delegate TContainer ContainerCreationCallback<TContainer, TObj>(TObj obj) where TContainer : IContainer<TObj>;

public interface IContainer<TObj>
{
    TObj Value { get; }
}