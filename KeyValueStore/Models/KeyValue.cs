﻿using System;
namespace KeyValueStore.Models
{
    public class KeyValue
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
