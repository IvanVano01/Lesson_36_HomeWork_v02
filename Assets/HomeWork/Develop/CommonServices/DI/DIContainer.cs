using System;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.DI
{
    public class DIContainer
    {
        private readonly Dictionary<Type, Registration> _container = new(); // сам контейнер ввиде словаря

        private readonly DIContainer _parent; // поле для родительского контейнера

        private readonly List<Type> _requests = new();//временный список будет хранить обращения к зависимостям, для обработки циклических зависимостей

        public DIContainer() : this(null)
        {

        }

        public DIContainer(DIContainer parent)
        {
            _parent = parent;
        }

        public void RegisterAsSingle<T>(Func<DIContainer, T> creator) // регаем объект в единственном экземпляре
        {
            if (_container.ContainsKey(typeof(T)))
                throw new InvalidOperationException($" {nameof(T)} Already register!");

            Registration registration = new Registration(container => creator(container));// создаём регистрацию 
            
            _container.Add(typeof(T), registration);// добавляем регистрацию в контейнер
            //_container[typeof(T)] = registration;// вариант добавления в словарь
        } 

        public T Resolve<T>()
        {
            if (_requests.Contains(typeof(T)))// если список уже хранит такую зависимость
                throw new InvalidOperationException($" Cycle resolve for {typeof(T)}");

            _requests.Add(typeof(T));// добавляем обращение к зависимости

            try
            {
                if (_container.TryGetValue(typeof(T), out Registration registration))// проверили что контейнер содержит запись о запрашиваемой регистрации
                    return CreateFrom<T>(registration);

                if (_parent != null)// если в локальном контейнере нет записи регистрации, запрашиваем у родительского контейнера
                    return _parent.Resolve<T>();
            }
            finally
            {
                _requests.Remove(typeof(T));// удаляем из списка
            }

            throw new InvalidOperationException($" Registration for {typeof(T)} not exist");
        }

        private T CreateFrom<T>(Registration registration)// метод будет принимать созданную регистрацию из контейнера и записывать в поле "Instance" и возвращать её
        {
            if (registration.Instance == null && registration.Creator != null)// проверяем что мы ещё не создавали такую регистрацию
                registration.Instance = registration.Creator(this);

            return (T)registration.Instance;
        }

        public class Registration
        {
            public Func<DIContainer, object> Creator { get; }// делегат принимает контейнер, возвращает созданный объект

            public object Instance { get; set; }

            public Registration(object instance)
            {
                Instance = instance;
            }

            public Registration(Func<DIContainer, object> creator)
            {
                Creator = creator;
            }
        }
    }
}
