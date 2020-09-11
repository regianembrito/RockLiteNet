using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RockLikeNet.Models;

namespace RockLikeNet.Controllers
{
    [RoutePrefix("Api/Article")]
    public class ArticleController : ApiController
    {
        RockLikeDBEntities dbEntities = new RockLikeDBEntities();

        // GET: api/Article/5
        [Route("ArticleById")]
        [HttpGet]
        public object Get(int id)
        {
            var obj = dbEntities.Articles.Where(x => x.IdArticle == id).ToList().FirstOrDefault();
            return obj;
        }

        // PUT: api/Article/5
        public object Put(int id, [FromBody]Article article)
        {
            try
            {
                if (article.IdArticle != 0)
                {
                    var obj = dbEntities.Articles.Where(x => x.IdArticle == article.IdArticle).ToList().FirstOrDefault();
                    if (obj.IdArticle > 0)
                    {
                        obj.LikeCount = obj.LikeCount + 1;
                        dbEntities.SaveChanges();

                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not updated"
            };
        }
    }
}
