using EasyTools.MySqlDatabaseTools;
using EasyTools.MySqlDatabaseTools.Queries;
using EasyTools.MySqlDatabaseTools.Tables;
using SynthesisEntities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer.Products
{
    public class DBProducts : IProductRepo
    {
        private readonly MySqlTable productsTable = new MySqlTable("sy_products");
        private readonly IDatabaseCommunicator database = new MySqlCommunicator(Metadata.HERADB);


        public void Add(Product p)
        {
            InsertQuery query = new InsertQuery(productsTable, p);
            database.Insert(query);
        }

        public IReadOnlyCollection<IReadOnlyParameterValueCollection> GetByName(string name)
        {
            MySqlCondition condition = new MySqlCondition("name", "%" + name + "%", Strictness.MustBeSimilar);
            SelectQuery selectQuery = new SelectQuery(productsTable, "*", condition);

            return database.Select(selectQuery);
        }
    }
}
