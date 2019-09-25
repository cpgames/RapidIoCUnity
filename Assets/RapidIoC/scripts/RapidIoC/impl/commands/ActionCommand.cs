﻿using System;

namespace cpGames.core.RapidIoC.impl
{
    internal interface IActionCommand : IBaseCommand { }

    internal class ActionCommand : Command, IActionCommand
    {
        #region Fields
        private readonly Action _action;
        #endregion

        #region Constructors
        public ActionCommand(Action action)
        {
            _action = action;
        }
        #endregion

        #region Methods
        public override void Execute()
        {
            _action();
        }
        #endregion
    }

    public class ActionCommand<T> : Command<T>, IActionCommand
    {
        #region Fields
        private readonly Action<T> _action;
        #endregion

        #region Constructors
        public ActionCommand(Action<T> action)
        {
            _action = action;
        }
        #endregion

        #region Methods
        public override void Execute(T type1)
        {
            _action(type1);
        }
        #endregion
    }

    public class ActionCommand<T, U> : Command<T, U>, IActionCommand
    {
        #region Fields
        private readonly Action<T, U> _action;
        #endregion

        #region Constructors
        public ActionCommand(Action<T, U> action)
        {
            _action = action;
        }
        #endregion

        #region Methods
        public override void Execute(T type1, U type2)
        {
            _action(type1, type2);
        }
        #endregion
    }
}