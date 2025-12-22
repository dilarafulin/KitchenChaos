using System;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IHasProgress 
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs :EventArgs
    { 
        public float progressNormalized;
    }
}
