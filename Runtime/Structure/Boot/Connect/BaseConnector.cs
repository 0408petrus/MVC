using System;
using System.Collections;

namespace Framework.Architecture.Base
{
    public abstract class BaseConnector : IConnector
    {
        public IEnumerator Init()
        {
            InitDependencies();
            yield return null;
            Connect();
            yield return null;
        }

        public IEnumerator Terminate()
        {
            Disconnect();
            yield return null;
        }

        protected virtual void InitDependencies()
        {
            Context.Instance.InjectDependencies(this);
        }

        protected void Subscribe<TMessage>(Action<TMessage> subscriber)
        {
            Context.Instance.Subscribe(subscriber);
        }

        protected void Unsubscribe<TMessage>(Action<TMessage> subscriber)
        {
            Context.Instance.Unsubscribe(subscriber);
        }

        #region Abstract
        protected abstract void Connect();
        protected abstract void Disconnect();
        #endregion
    }
}
