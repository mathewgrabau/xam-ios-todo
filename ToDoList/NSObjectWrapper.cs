// NSObjectWrapper.cs
// Implements a compatibility wrapper for NSObject and standard CLR object type.

using Foundation;

namespace ToDoList
{
    public class NSObjectWrapper<TWrapped> : NSObject
    {
        public TWrapped Context;

        public NSObjectWrapper(TWrapped obj) : base()
        {
            Context = obj;
        }

        public static NSObjectWrapper<TWrapped> Wrap(ref TWrapped instance)
        {
            return new NSObjectWrapper<TWrapped>(instance);
        }

        // TODO maybe extend NSObject!?
        public static TWrapped Unwrap(ref NSObject instance)
        {
            if (instance is NSObjectWrapper<TWrapped> wrappedInstance)
            {
                return wrappedInstance.Context;
            }

            return default(TWrapped);
        }
    }
}
