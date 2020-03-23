using System;
namespace ArticlePuzzle
{
    public class Article
    {

        private string nome;
        private string siteArticle;
        private string url;

        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public string SiteArticle
        {
            get
            {
                return siteArticle;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public Article()
        {
        }
    }

    //internal class per il ranking dell'article
    internal class ArticleRanking
    {
        public int rankingInitial { get; set; }
        public int impactOnRanking { get; set; }
        public int rankingFinal { get; set; }

        public void SetTotalRanking(string action)
        {
            switch (action)
            {
                case "like":
                    rankingFinal = rankingInitial + impactOnRanking;
                    break;
                case "dislike":
                    rankingFinal = rankingInitial - impactOnRanking;
                    break;
            }

    
        }
    }
}
