﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace cpGames.core.RapidMVC.impl
{
    internal class KeyFactoryCollection : IKeyFactoryCollection
    {
        #region Fields
        private readonly List<IKeyFactory> _factories = new List<IKeyFactory>();
        #endregion

        #region Constructors
        public KeyFactoryCollection()
        {
            if (!AddFactory(new NameKeyFactory(), out var errorMessage) ||
                !AddFactory(new TypeKeyFactory(), out errorMessage) ||
                !AddFactory(new UidKeyFactory(), out errorMessage))
            {
                throw new Exception(errorMessage);
            }
        }
        #endregion

        #region IKeyFactoryCollection Members
        public bool Create(object keyData, out IKey key, out string errorMessage)
        {
            if (keyData is IKey)
            {
                key = (IKey)keyData;
                errorMessage = string.Empty;
                return true;
            }
            foreach (var factory in _factories)
            {
                if (factory.Create(keyData, out key, out errorMessage))
                {
                    return true;
                }
            }
            key = null;
            errorMessage = "Failed to create binding key, no matching key factory found.";
            return false;
        }

        public bool AddFactory(IKeyFactory factory, out string errorMessage)
        {
            if (_factories.Any(x => x.GetType() == factory.GetType()))
            {
                errorMessage = string.Format("Factory of type <{0}> already exists.", factory.GetType().Name);
                return false;
            }
            _factories.Add(factory);
            errorMessage = string.Empty;
            return true;
        }
        #endregion
    }
}