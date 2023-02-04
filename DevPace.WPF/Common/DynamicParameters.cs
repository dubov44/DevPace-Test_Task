using System.Collections.Generic;

namespace DevPace.WPF.Common
{
    public class DynamicParameters
    {
        private IDictionary<string, object> _params;

        public DynamicParameters()
        {
            _params = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            set => _params[key] = value;
        }

        public T? GetItem<T>(string key)
        {
            if (!_params.ContainsKey(key))
                return default;

            var value = _params[key];
            _params.Remove(key);
            return (T)value;
        }
    }
}
