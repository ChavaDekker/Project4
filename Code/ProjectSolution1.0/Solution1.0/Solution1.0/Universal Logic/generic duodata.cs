using System;
namespace Solution1._0.Universal_Logic
{
    public class Duodata<T, U>
    {
        private T Attr1;
        private U Attr2;

        public T GetAttr1()
        {
            return Attr1;
        }
        public U GetAttr2()
        {
            return Attr2;
        }
        public Duodata(T attr1, U attr2)
        {
            Attr1 = attr1;
            Attr2 = attr2;
        }

    }
}
