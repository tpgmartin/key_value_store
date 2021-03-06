﻿using KeyValueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace KeyValueStore.Services
{
    public class InMemoryKeyValueStore : IKeyValueStore
    {
        private readonly KeyValuesAPIContext _context;

        public InMemoryKeyValueStore(KeyValuesAPIContext context)
        {
            _context = context;
        }

        public KeyValue Add(KeyValue keyValue)
        {
            var addedKeyValue = _context.Add(keyValue);
            _context.SaveChanges();

            return keyValue;
        }

        public void Delete(KeyValue keyValue)
        {
            _context.Remove(keyValue);
            _context.SaveChanges();
        }

        public IEnumerable<KeyValue> GetAll()
        {
            return _context.KeyValues.ToList();
        }

        public KeyValue GetByKey(string key)
        {
            return _context.KeyValues.SingleOrDefault(x => x.Key == key);
        }

        public void Update(KeyValue keyValue)
        {
            var keyValueToUpdate = GetByKey(keyValue.Key);
			keyValueToUpdate.Value = keyValue.Value;
            keyValueToUpdate.LastUpdated = keyValue.LastUpdated;
			_context.Update(keyValueToUpdate);
			_context.SaveChanges();  
        }
    }
}
