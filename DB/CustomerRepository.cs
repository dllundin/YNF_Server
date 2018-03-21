using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YNF_Server.Models;

namespace YNF_Server.DB
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context = null;
        public CustomerRepository(IOptions<Settings> settings)
        {
            _context = new CustomerContext(settings);
        }

        public async Task Create(Customer customer)
        {
            try
            {
                await _context.Customers.InsertOneAsync(customer);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Delete(int ID)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Customers.DeleteOneAsync(
                        Builders<Customer>.Filter.Eq("Id", ID));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task<bool> RemoveAll()
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Customers.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Customer> Get(int ID)
        {
            try
            {
                return await _context.Customers
                        .Find(c => c.ID == ID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                return await _context.Customers
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Customers
                                    .ReplaceOneAsync(c => c.ID.Equals(customer.ID)
                                            , customer
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> CreateBulk(IEnumerable<Customer> customers)
        {
            try
            {
                await _context.Customers.InsertManyAsync(customers);
                return true;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
