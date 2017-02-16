using EPiServer.Core;
using EPiServer.Framework.Serialization;
using EPiServer.Framework.Serialization.Internal;
using EPiServer.ServiceLocation;

namespace Brightfind.EktronToEpiserverLab.Models.Properties
{
    public class PropertyListBase<T> : PropertyList<T>
    {
        private readonly IObjectSerializer _serializer;
        private Injected<ObjectSerializerFactory> _objectSerializerFactory;

        public PropertyListBase()
        {
            _serializer = _objectSerializerFactory.Service.GetSerializer("application/json");
        }

        public override PropertyData ParseToObject(string value)
        {
            ParseToSelf(value);
            return this;
        }

        protected override T ParseItem(string value) => _serializer.Deserialize<T>(value);
    }
}