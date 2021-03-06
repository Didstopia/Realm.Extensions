﻿using System;

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
        public BaseException() : base()
        {
        }

        public BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, Exception inner) : base(message, inner)
        {
        }
        #endregion
    }
}
