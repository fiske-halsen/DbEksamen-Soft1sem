using Neo4j.Driver;
using System.Text;

namespace Neo4JAPI.Repository
{   
    public interface IRecommendationRepository
    {
        public Task AddCustomerRestaurantRelation(string restaurantName, string customerName);
    }
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly IDriver _driver;

        public RecommendationRepository()
        {
            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "password"));
        }




        public async Task AddCustomerRestaurantRelation(string restaurantName, string customerName)
        {
            var statementText = new StringBuilder();
            statementText.Append("MERGE (p:Person {name: $cName})");
            statementText.Append("MERGE (r:Restaurant {name: $rName})");
            statementText.Append("CREATE (p)-[:ORDERS_FROM]->(r)");

            var statementParameters = new Dictionary<string, object>
        {

            {"rName", restaurantName },
            {"cName", customerName }
            
        };

            var session = this._driver.AsyncSession();
            var result = await session.WriteTransactionAsync(tx => tx.RunAsync(statementText.ToString(), statementParameters));
            
        }
    }
}
