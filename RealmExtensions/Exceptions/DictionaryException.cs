using System;

namespace Didstopia.RealmExtensions.Exceptions
{
    public class DictionaryException : BaseException
    {
        public DictionaryException()
        {
            
        }

        public override string TestProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void TestFunction()
        {
            throw new NotImplementedException();
        }
    }
}
