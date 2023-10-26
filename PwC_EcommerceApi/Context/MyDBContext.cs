using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PwC_EcommerceApi.Model;
using System.Security.Authentication;

namespace PwC_EcommerceApi.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> option): base(option) { 
        
        }

        public DbSet<Order> Order { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbName = "Ecommerce";
            string connectionString = "mongodb://pwctask:ngnXXXtqv690HqT7uWP7xIR16hgMdSaSplsuzF5V0w91EK9VIRSa3ntsGEIpRbOayStYuz6URcydACDbvg9RMg==@pwctask.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@pwctask@";
            var endPoint = "https://pwctask.mongo.cosmos.azure.com:443/";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            mongoClient.GetDatabase(dbName);

            //optionsBuilder.UseCosmos(
            //    "YourCosmosDBEndpoint",
            //    "YourAuthKey",
            //    "YourDatabaseId"
            //);
            optionsBuilder.UseCosmos(endPoint, connectionString, dbName);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>(p =>
        //    {
        //        p.ToContainer("Order");
        //        p.HasPartitionKey(x => x.PartitionKey);
        //        p.OwnsMany(o => o.OrderItems);
        //        p.OwnsOne(x => x.Customer, n =>
        //        {
        //            n.OwnsOne(a => a.Address);
        //        });
        //    });
        //   // base.OnModelCreating(modelBuilder);
        //}
    }
}
