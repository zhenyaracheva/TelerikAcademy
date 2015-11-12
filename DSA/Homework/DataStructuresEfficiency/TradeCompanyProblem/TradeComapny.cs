namespace TradeCompanyProblem
{
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class TradeComapny
    {
        private OrderedMultiDictionary<decimal, Article> articles;

        public TradeComapny()
        {
            this.articles = new OrderedMultiDictionary<decimal, Article>(true);
        }

        public void Add(Article article)
        {
            this.articles[article.Price].Add(article);
        }

        public ICollection<Article> FindByPraceRange(decimal startPrice, decimal endPrice)
        {
            return this.articles.Range(startPrice, true, endPrice, true).Values;
        }
    }
}
