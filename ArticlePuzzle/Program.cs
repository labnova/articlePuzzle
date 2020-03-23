using System;
using System.Reflection;
using ArticlePuzzle;

namespace ArticlePuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            //utilizzare .GetMethod per prendere la Method Info
            Type objInitialRanking = typeof(ArticleRanking);
            object obj = Activator.CreateInstance(objInitialRanking);

            //prendere le properties e settare l'initialRanking a 100
            //TODO: IMPLEMENTARE MECCANISMO DI STORAGE PER RIPRENDERE IL RANKING INITIAL
            foreach (PropertyInfo prop in objInitialRanking.GetProperties())
            {
                if (prop.Name == "rankingInitial")
                {
                    prop.SetValue(obj, 100);
                }
            }

            MethodInfo mInfo = objInitialRanking.GetMethod("SetTotalRanking");

            //TODO: PER ADESSO INSERIRE PER TESTARE I LIKE E I DISLIKE, DA AGGIUNGERE IN LOGICA QUANDO ARRIVANO GLI ARTICLE
            setLikeForArticle(10, objInitialRanking, obj, mInfo);
            setDislikeForArticle(5, objInitialRanking, obj, mInfo);


        }

        //method per riprendere l'objInitialRanking e settare il grado di like preferito
        public static void setLikeForArticle(int like, Type objInitialRanking, object obj, MethodInfo mInfo)
        {
            foreach (PropertyInfo prop in objInitialRanking.GetProperties())
            {
                if (prop.Name == "impactOnRanking")
                {
                    prop.SetValue(obj, like);
                }
            }

            //FIXME: METTERE LE EXCEPTION SU mInfo
            mInfo.Invoke(obj, new String[] { "like" });
        }


        //method per riprendere l'objInitialRanking e togliere il grado di like preferito
        public static void setDislikeForArticle(int dislike, Type objInitialRanking, object obj, MethodInfo mInfo)
        {
            foreach (PropertyInfo prop in objInitialRanking.GetProperties())
            {
                if (prop.Name == "impactOnRanking")
                {
                    prop.SetValue(obj, dislike);
                }
            }

            mInfo.Invoke(obj, new String[] { "dislike" });

        }
    }
}
