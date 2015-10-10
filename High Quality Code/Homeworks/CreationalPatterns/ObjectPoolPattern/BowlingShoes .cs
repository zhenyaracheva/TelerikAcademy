namespace ObjectPoolPattern
{
    using System;
    using System.Collections.Generic;

    public class BowlingShoesStore<T> where T : IDisposable, new()
    {
        private readonly List<T> availableShoes = new List<T>();
        private readonly List<T> usedShoes = new List<T>();

        public BowlingShoesStore()
        {
        }

        public T GetShoes()
        {
            lock (this.availableShoes)
            {
                if (this.availableShoes.Count != 0)
                {
                    var shoes = this.availableShoes[0];
                    this.usedShoes.Add(shoes);
                    this.availableShoes.RemoveAt(0);
                    return shoes;
                }
                else
                {
                    var shoes = new T();
                    this.usedShoes.Add(shoes);
                    return shoes;
                }
            }
        }

        public void ReleaseShoes(T shoes)
        {
            shoes.Dispose();

            lock (this.availableShoes)
            {
                this.availableShoes.Add(shoes);
                this.usedShoes.Remove(shoes);
            }
        }
    }
}
