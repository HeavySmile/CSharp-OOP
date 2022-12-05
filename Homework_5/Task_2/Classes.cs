using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    #region Subtask a

    namespace a
    {
        public interface IEnumerator
        {
            bool MoveNext();
            object Current { get; }
            void Reset();
        }

        public class CountDown : IEnumerator
        {
            public CountDown()
            {
                Current = 16;
            }
            public bool MoveNext()
            {
                if ((int)Current != 0)
                {
                    Current = (int)Current - 1;
                    return true;
                }

                return false;
            }
            public object Current
            {
                get; set;
            }
            public void Reset()
            {
                Current = 16;
            }

        }
    }

    #endregion

    #region Subtask b

    namespace b
    {
        public interface IEnumerator
        {
            bool MoveNext()
            {
                if ((int)Current != 0)
                {
                    Current = (int)Current - 1;
                    return true;
                }

                return false;
            }
            object Current
            {
                get; protected set;
            }
            void Reset()
            {
                Current = 16;
            }

            public class CountDown : IEnumerator
            {
                public CountDown()
                {
                    Current = 16;
                }

                public bool MoveNext()
                {
                    if ((int)Current != 0)
                    {
                        Current = (int)Current - 1;
                        return true;
                    }

                    return false;
                }
                public object Current
                {
                    get; set;
                }
                public void Reset()
                {
                    Current = 16;
                }
            }
        }
    }

    #endregion

    #region Subtask c

    namespace c
    {
        public interface IEnumerator
        {
            bool MoveNext()
            {
                if ((int)Current != 0)
                {
                    Current = (int)Current - 1;
                    return true;
                }

                return false;
            }
            object Current
            {
                get; protected set;
            }
            void Reset()
            {
                Current = 16;
            }

            public class CountDown : IEnumerator
            {
                public CountDown()
                {
                    Current = 16;
                }

                public virtual bool MoveNext()
                {
                    if ((int)Current != 0)
                    {
                        Current = (int)Current - 1;
                        return true;
                    }

                    return false;
                }
                public object Current
                {
                    get; set;
                }
                public virtual void Reset()
                {
                    Current = 16;
                }
            }
        }

        public class CountDownWithOverride : IEnumerator.CountDown
        {
            public CountDownWithOverride()
            {
                Current = 0;
            }
            public override bool MoveNext()
            {
                if ((int)Current != 16)
                {
                    Current = (int)Current + 1;
                    return true;
                }

                return false;
            }
            public override void Reset()
            {
                Current = 0;
            }
        }

    }

    #endregion

    #region Subtask d

    namespace d
    {
        public interface IEnumerator
        {
            bool MoveNext()
            {
                if ((int)Current != 0)
                {
                    Current = (int)Current - 1;
                    return true;
                }

                return false;
            }
            object Current
            {
                get; protected set;
            }
            void Reset()
            {
                Current = 16;
            }

            public class CountDown : IEnumerator
            {
                public CountDown()
                {
                    (this as IEnumerator).Current = 16;
                }

                bool IEnumerator.MoveNext()
                {
                    if ((int)(this as IEnumerator).Current != 0)
                    {
                        (this as IEnumerator).Current = (int)(this as IEnumerator).Current - 1;
                        return true;
                    }

                    return false;
                }
                object IEnumerator.Current
                {
                    get; set;
                }
                void IEnumerator.Reset()
                {
                    (this as IEnumerator).Current = 16;
                }
            }
        }
    }
    #endregion
}
