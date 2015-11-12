namespace TradeCompanyProblem
{
    using System;

    public class Article : IComparable
    {
        public Article(string barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            var article = obj as Article;
            return this.Price.CompareTo(article.Price);
        }
    }
}
