using Neo4j.Driver;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Neo4JAPI.Repository
{   
    public interface IRecommendationRepository
    {
        public Task AddCustomerRestaurantRelation(string restaurantName, string customerName);
        public Task AddRestaurantTypeRelation(string restaurantName, string restaurantType);
        public Task <string> FindFavoriteRestaurantFromCustomerName(string customerName);
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

        public async Task AddRestaurantTypeRelation(string restaurantName, string restaurantType)
        {
            var statementText = new StringBuilder();
            statementText.Append("MERGE (r:Restaurant {name: $rName})");
            statementText.Append("MERGE (t:R_Type {type: $rType})");
            statementText.Append("MERGE (r)-[:TYPE_OF]->(t)");
            
            var statementParameters = new Dictionary<string, object>
        {

            {"rName", restaurantName },
            {"rType", restaurantType }

        };

            var session = this._driver.AsyncSession();
            var result = await session.WriteTransactionAsync(tx => tx.RunAsync(statementText.ToString(), statementParameters));
        }

        public async Task <string> FindFavoriteRestaurantFromCustomerName(string customerName)
        {
            var statementText = new StringBuilder();
            statementText.Append("MATCH (p:Person {name: 'niels'})-[:ORDERS_FROM]->(r:Restaurant)-[:TYPE_OF]->(t:R_Type) RETURN count(*) AS occurrence, t.type ORDER BY occurrence DESC");
            


            var statementParameters = new Dictionary<string, object>
        {

            {"cName", customerName }
            

        };

           
            return "hej";
        }
    }
}
