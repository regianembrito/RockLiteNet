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
            var obj = dbEntities.ARTICLES.Where(x => x.ID_ARTICLE == id).ToList().FirstOrDefault();
            return obj;
        }

        // PUT: api/Article/5
        public object Put(int id, [FromBody]ARTICLE article)
        {
            try
            {
                if (article.ID_ARTICLE != 0)
                {
                    var obj = dbEntities.ARTICLES.Where(x => x.ID_ARTICLE == article.ID_ARTICLE).ToList().FirstOrDefault();
                    if (obj.ID_ARTICLE > 0)
                    {
                        obj.LIKE_COUNT = obj.LIKE_COUNT + 1;
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
