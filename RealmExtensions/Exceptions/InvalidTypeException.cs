using System;

namespace Didstopia.RealmExtensions.Exceptions
{
    public class InvalidTypeException : BaseException
    {
        #region Constructors
        public InvalidTypeException(Type type) : base($"{type.ToString()} is not a supported Realm object type.")
        {
            
        }
        #endregion

        public override string TestProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void TestFunction()
        {
            throw new NotImplementedException();
        }
    }
}
