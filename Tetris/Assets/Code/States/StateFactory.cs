
    using Zenject;
    using System;

    public interface  IStateFactory : IFactory
    {
        T Create<T>() where T : IState;
        T Create<T>(Type type) where T : IState;
    }

    public class StateFactory : IStateFactory {

        private DiContainer _container = default;

        public StateFactory(DiContainer container) {
            _container = container;
        }

        public T Create<T>() where T : IState {
            return Create<T>(typeof(T));
        }

        public T Create<T>(Type type) where T : IState {
            var state = (T) _container.Resolve<T>();
            if (state == null) throw new OperationCanceledException($"Cannot create state of type {type.ToString()}");

            return state;
        }

        public IState Create() {
            throw new NotImplementedException();
        }
    }
