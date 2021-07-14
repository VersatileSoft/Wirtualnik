using System.Dynamic;

namespace Wirtualnik.Shared.Models.Base
{
    public class Resource<T> : Statement where T : class
    {
        public T? Result { get; set; }
        public dynamic Meta { get; set; }

        #region Resource()
        public Resource()
        {
            Meta = new ExpandoObject();
        }

        public Resource(T data) : this()
        {
            Result = data;
        }

        public static Resource<T> FromT(T data)
        {
            return new Resource<T>(data);
        }
        #endregion
    }

    public static class TResource
    {
        public static Resource<T> FromT<T>(T data) where T : class
        {
            return new Resource<T>(data);
        }
    }
}