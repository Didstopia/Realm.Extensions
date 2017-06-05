using System;

namespace Didstopia.RealmExtensions.Exceptions
{
    public abstract class BaseException : Exception
    {
        #region Properties
        public abstract string TestProperty { get; set; }
        #endregion

        #region Methods
        public abstract void TestFunction();
        #endregion

        #region Constructors
        protected BaseException() : base()
        {
        }

        protected BaseException(string message) : base(message)
        {
        }

        protected BaseException(string message, Exception inner) : base(message, inner)
        {
        }
        #endregion
    }
}
