using UnityEngine;

namespace Modules.Game.Scripts
{
    public interface IFactory
    {
        public object Create();
        public object Create(Vector3 startPosition);
        public object Create(Vector3 startPosition, Transform parent);
        public object Create(Vector3 startPosition, Vector3 rotation ,Transform parent);
    }
}