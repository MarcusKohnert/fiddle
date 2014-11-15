using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityReloadingModelBinding
{
    public class Repo
    {
        private static Lazy<DocumentStore> store = new Lazy<DocumentStore>(() =>
        {
            var docStore = new DocumentStore
            {
                Url = "http://nb252:8080",
                DefaultDatabase = "EntityDB"
            };

            docStore.Initialize();
            return docStore;
        });

        public void Save<T>(T entity)
        {
            using (var session = store.Value.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        public T Get<T>(int id)
        {
            using (var session = store.Value.OpenSession())
            {
                return session.Load<T>(id);
            }
        }
    }
}