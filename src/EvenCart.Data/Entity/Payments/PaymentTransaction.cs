﻿using System;
using System.Collections.Generic;
using EvenCart.Core.Data;
using EvenCart.Data.Entity.Purchases;
using Newtonsoft.Json;

namespace EvenCart.Data.Entity.Payments
{
    public class PaymentTransaction : FoundationEntity, ISoftDeletable
    {
        public string TransactionGuid { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        public string OrderGuid { get; set; }

        public decimal TransactionAmount { get; set; }

        public string UserIpAddress { get; set; }

        public string PaymentMethodName { get; set; }

        #region Virtual Properties
        private Dictionary<string, object> _transactionCodes;

        public virtual Dictionary<string, object> TransactionCodes
        {
            get
            {
                _transactionCodes = _transactionCodes ?? new Dictionary<string, object>();
                return _transactionCodes;
            }
            set => _transactionCodes = value;
        }

        public virtual Order Order { get; set; }

        #endregion

        //use serialized string to store data
        public string TransactionCodesSerialized
        {
            get => JsonConvert.SerializeObject(TransactionCodes);
            set => TransactionCodes = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
        }

        public string TransactionCurrencyCode { get; set; }

        public bool Deleted { get; set; }
    }

}